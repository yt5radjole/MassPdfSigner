using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;

using Org.BouncyCastle.X509;

using IOPath = System.IO.Path;
using PdfRectangle = iTextSharp.text.Rectangle;

namespace MassPdfSigner
{
    public static class PdfSignerService
    {
        // =============================================
        // PODESIVI OFFSETI TEKSTA UNUTAR PRAVOUGAONIKA
        // +X = desno, -X = levo
        // +Y = gore,  -Y = dole
        // =============================================
        private const float TEXT_OFFSET_X = 2f;   // pomeraj po X
        private const float TEXT_OFFSET_Y = 4f;   // pomeraj po Y

        // Putanja ka ćiriličnom fontu (FreeSerif.ttf) – mora da postoji u fonts folderu
        private static readonly string FontPath =
            IOPath.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", "FreeSerif.ttf");

        /// <summary>
        /// Pojedinačno potpisivanje
        /// </summary>
        public static void SignSinglePdf(
            string inputPath,
            string outputPath,
            SignatureCorner corner,
            bool autoFreeCorner = false,
            float? manualXRel = null,
            float? manualYRel = null,
            bool signOnLastPage = true)   // true = poslednja, false = prva
        {
            if (!File.Exists(inputPath))
                throw new FileNotFoundException("Ulazni PDF ne postoji.", inputPath);

            using (Pkcs11Manager pkcs11 = Pkcs11Manager.InitializeWithPin(null))
            {
                X509Certificate bcCert = pkcs11.Certificate;
                string imePrezime = ExtractName(bcCert.SubjectDN.ToString());
                string visibleText = BuildVisibleSignatureText(imePrezime);

                var chain = new List<X509Certificate> { bcCert };
                var externalSignature =
                    new Pkcs11ExternalSignature(pkcs11.Session, pkcs11.PrivateKeyHandle);

                using (PdfReader reader = new PdfReader(inputPath))
                using (FileStream os = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    int pageToSign = signOnLastPage ? reader.NumberOfPages : 1;

                    // Dimenzije pravougaonika potpisa
                    float sigWidthPt = 100f;
                    float sigHeightPt = 30f;

                    PdfRectangle rect = GetSignatureRectangle(
                        reader,
                        corner,
                        pageToSign,
                        sigWidthPt,
                        sigHeightPt,
                        autoFreeCorner,
                        manualXRel,
                        manualYRel);

                    PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
                    PdfSignatureAppearance appearance = stamper.SignatureAppearance;

                    appearance.Reason = "Elektronsko potpisivanje";
                    appearance.Location = "Srbija";

                    appearance.SetVisibleSignature(rect, pageToSign, "Signature1");

                    // ===== VEKTORSKI TEKST U LAYER 2 =====
                    BaseFont bf = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    DrawLayer2Text(appearance, visibleText, bf);

                    // Kriptografski deo
                    MakeSignature.SignDetached(
                        appearance,
                        externalSignature,
                        chain,
                        null,
                        null,
                        null,
                        0,
                        CryptoStandard.CADES);
                }
            }
        }

        /// <summary>
        /// Masovno potpisivanje
        /// </summary>
        public static void SignAllInFolder(
            string inputFolder,
            string outputFolder,
            string archiveFolder,
            SignatureCorner corner,
            bool autoFreeCorner = false,
            float? manualXRel = null,
            float? manualYRel = null,
            bool signOnLastPage = true)
        {
            if (!Directory.Exists(inputFolder))
                throw new DirectoryNotFoundException("Ulazni folder ne postoji: " + inputFolder);

            Directory.CreateDirectory(outputFolder);

            bool doArchive = !string.IsNullOrWhiteSpace(archiveFolder);
            if (doArchive)
                Directory.CreateDirectory(archiveFolder);

            using (Pkcs11Manager pkcs11 = Pkcs11Manager.InitializeWithPin(null))
            {
                X509Certificate bcCert = pkcs11.Certificate;
                string imePrezime = ExtractName(bcCert.SubjectDN.ToString());
                string visibleText = BuildVisibleSignatureText(imePrezime);

                var chain = new List<X509Certificate> { bcCert };
                var externalSignature =
                    new Pkcs11ExternalSignature(pkcs11.Session, pkcs11.PrivateKeyHandle);

                // Font možemo kreirati jednom
                BaseFont bf = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                string[] files = Directory.GetFiles(inputFolder, "*.pdf");
                foreach (string file in files)
                {
                    string dest = IOPath.Combine(
                        outputFolder,
                        IOPath.GetFileNameWithoutExtension(file) + "_signed.pdf");

                    try
                    {
                        using (PdfReader reader = new PdfReader(file))
                        using (FileStream os = new FileStream(dest, FileMode.Create, FileAccess.Write))
                        {
                            int pageToSign = signOnLastPage ? reader.NumberOfPages : 1;

                            float sigWidthPt = 100f;
                            float sigHeightPt = 30f;

                            PdfRectangle rect = GetSignatureRectangle(
                                reader,
                                corner,
                                pageToSign,
                                sigWidthPt,
                                sigHeightPt,
                                autoFreeCorner,
                                manualXRel,
                                manualYRel);

                            PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
                            PdfSignatureAppearance appearance = stamper.SignatureAppearance;

                            appearance.Reason = "Masovno potpisivanje";
                            appearance.Location = "Srbija";

                            appearance.SetVisibleSignature(rect, pageToSign, "Signature1");

                            // Vektorski tekst u Layer 2
                            DrawLayer2Text(appearance, visibleText, bf);

                            MakeSignature.SignDetached(
                                appearance,
                                externalSignature,
                                chain,
                                null,
                                null,
                                null,
                                0,
                                CryptoStandard.CADES);
                        }

                        if (doArchive)
                        {
                            string dateFolder = IOPath.Combine(
                                archiveFolder,
                                DateTime.Now.ToString("yyyy"),
                                DateTime.Now.ToString("MM"),
                                DateTime.Now.ToString("dd"));

                            Directory.CreateDirectory(dateFolder);

                            string archPath = IOPath.Combine(dateFolder, IOPath.GetFileName(file));
                            if (File.Exists(archPath))
                                File.Delete(archPath);

                            File.Move(file, archPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Greška pri potpisivanju fajla " + file + ": " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Preview – potpisuje u temp fajl i otvara PDF viewer.
        /// </summary>
        public static void PreviewSignature(
            string inputPath,
            SignatureCorner corner,
            bool autoFreeCorner = false,
            float? manualXRel = null,
            float? manualYRel = null,
            bool signOnLastPage = true)
        {
            string tempFolder = IOPath.GetTempPath();
            string tempFile = IOPath.Combine(
                tempFolder,
                IOPath.GetFileNameWithoutExtension(inputPath) + "_preview_signed.pdf");

            SignSinglePdf(inputPath, tempFile, corner, autoFreeCorner, manualXRel, manualYRel, signOnLastPage);

            try
            {
                Process.Start(tempFile);
            }
            catch
            {
                // ako nema default viewer-a – ništa
            }
        }

        // =========================================================
        //   CRTANJE VEKTORSKOG TEKSTA U LAYER 2
        // =========================================================
        private static void DrawLayer2Text(PdfSignatureAppearance appearance, string visibleText, BaseFont bf)
        {
            PdfTemplate layer2 = appearance.GetLayer(2);

            float startX = TEXT_OFFSET_X;
            float startY = layer2.BoundingBox.Height - 12f + TEXT_OFFSET_Y;

            layer2.BeginText();
            layer2.SetFontAndSize(bf, 8f);
            layer2.SetRGBColorFill(0, 70, 160); // plava

            string[] lines = visibleText.Split('\n');
            float lineHeight = 10f;

            for (int i = 0; i < lines.Length; i++)
            {
                float y = startY - (i * lineHeight);
                layer2.SetTextMatrix(startX, y);
                layer2.ShowText(lines[i]);
            }

            layer2.EndText();
        }

        // =========================================================
        //   Pravougaonik potpisa
        // =========================================================
        private static PdfRectangle GetSignatureRectangle(
            PdfReader reader,
            SignatureCorner corner,
            int page,
            float sigWidth,
            float sigHeight,
            bool autoFreeCorner,
            float? manualXRel,
            float? manualYRel)
        {
            PdfRectangle ps = reader.GetPageSize(page);

            float m = 20f;

            float maxWidth = ps.Width - 2 * m;
            float maxHeight = ps.Height - 2 * m;

            if (sigWidth > maxWidth) sigWidth = maxWidth;
            if (sigHeight > maxHeight) sigHeight = maxHeight;

            Func<float, float, PdfRectangle> rectAt =
                (x, y) =>
                {
                    float llx = x;
                    float lly = y;
                    float urx = llx + sigWidth;
                    float ury = lly + sigHeight;

                    // Ograniči u margine stranice
                    if (llx < ps.Left + m)
                    {
                        llx = ps.Left + m;
                        urx = llx + sigWidth;
                    }
                    if (urx > ps.Right - m)
                    {
                        urx = ps.Right - m;
                        llx = urx - sigWidth;
                    }

                    if (lly < ps.Bottom + m)
                    {
                        lly = ps.Bottom + m;
                        ury = lly + sigHeight;
                    }
                    if (ury > ps.Top - m)
                    {
                        ury = ps.Top - m;
                        lly = ury - sigHeight;
                    }

                    return new PdfRectangle(llx, lly, urx, ury);
                };

            // Ručna relativna pozicija (0..1, 0..1)
            if (corner == SignatureCorner.Manual &&
                manualXRel.HasValue &&
                manualYRel.HasValue)
            {
                float llxMan = ps.Left + manualXRel.Value * (ps.Width - sigWidth);
                float llyMan = ps.Bottom + manualYRel.Value * (ps.Height - sigHeight);
                return rectAt(llxMan, llyMan);
            }

            PdfRectangle bottomLeft = rectAt(ps.Left + m, ps.Bottom + m);
            PdfRectangle bottomRight = rectAt(ps.Right - m - sigWidth, ps.Bottom + m);
            PdfRectangle topLeft = rectAt(ps.Left + m, ps.Top - m - sigHeight);
            PdfRectangle topRight = rectAt(ps.Right - m - sigWidth, ps.Top - m - sigHeight);
            PdfRectangle center = rectAt(
                ps.Left + (ps.Width - sigWidth) / 2,
                ps.Bottom + (ps.Height - sigHeight) / 2);

            if (autoFreeCorner)
            {
                // za sada – donji desni
                return bottomRight;
            }

            switch (corner)
            {
                case SignatureCorner.TopLeft:
                    return topLeft;
                case SignatureCorner.TopRight:
                    return topRight;
                case SignatureCorner.BottomLeft:
                    return bottomLeft;
                case SignatureCorner.BottomRight:
                    return bottomRight;
                case SignatureCorner.Center:
                    return center;
                default:
                    return bottomRight;
            }
        }

        // =========================================================
        //   Ekstrakcija imena
        // =========================================================
        private static string ExtractName(string subjectDn)
        {
            int idx = subjectDn.IndexOf("CN=");
            if (idx < 0)
                return "Непознато";

            string cn = subjectDn.Substring(idx + 3);
            int comma = cn.IndexOf(',');
            if (comma > 0)
                cn = cn.Substring(0, comma);

            cn = cn.Trim();

            // ODMASNITI SVE BROJEVE – uklanjamo broj lične karte
            // Primer: "Marko Marković 1234567890123" → "Marko Marković"
            string onlyLetters = "";
            foreach (char c in cn)
            {
                if (!char.IsDigit(c))
                    onlyLetters += c;
            }
            cn = onlyLetters.Trim();

            // Ako ostane višak razmaka
            while (cn.Contains("  "))
                cn = cn.Replace("  ", " ");

            // Ukloni "SIGN" ako postoji
            if (cn.EndsWith(" SIGN", StringComparison.OrdinalIgnoreCase) ||
                cn.EndsWith(" Sign", StringComparison.OrdinalIgnoreCase))
            {
                int lastSpace = cn.LastIndexOf(' ');
                if (lastSpace > 0)
                    cn = cn.Substring(0, lastSpace).Trim();
            }

            return cn;
        }


        // =========================================================
        //   Tekst vidljivog potpisa – ĆIRILICA
        // =========================================================
        private static string BuildVisibleSignatureText(string ime)
        {
            string now = DateTime.Now.ToString(
                "dd.MM.yyyy. HH:mm:ss",
                CultureInfo.GetCultureInfo("sr-Latn-RS"));

            return
                "Дигитално потписано\n" +
                ime + "\n" +
               // "Издавалац сертификата:\n" +
               // "Министарство унутрашњих послова Републике Србије\n" +
                now;
        }
    }
}
