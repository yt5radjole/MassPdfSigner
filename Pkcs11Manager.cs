using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using Org.BouncyCastle.X509;

namespace MassPdfSigner
{
    public class Pkcs11Manager : IDisposable
    {
        // PROVERI da li je ovo tvoja prava putanja do MUP PKCS#11 DLL-a!
        private const string LibraryPath = @"C:\Program Files\TrustEdgeID\netsetpkcs11_x86.dll";

        private Pkcs11 _pkcs11;
        private Session _session;
        private ObjectHandle _privateKeyHandle;
        private X509Certificate _certificate;

        public Session Session
        {
            get { return _session; }
        }

        public ObjectHandle PrivateKeyHandle
        {
            get { return _privateKeyHandle; }
        }

        public X509Certificate Certificate
        {
            get { return _certificate; }
        }

        private Pkcs11Manager()
        {
        }

        public static Pkcs11Manager InitializeWithPin(IWin32Window owner)
        {
            Pkcs11Manager mgr = new Pkcs11Manager();
            mgr.InitializeInternal(owner);
            return mgr;
        }

        private void InitializeInternal(IWin32Window owner)
        {
            // ✔ Pkcs11Interop 4.1.2 — pravi konstruktor (libraryPath, AppType)
            _pkcs11 = new Pkcs11(LibraryPath, AppType.MultiThreaded);

            // ✔ Dohvati sve slotove sa ubačenim tokenom
            List<Slot> slots = _pkcs11.GetSlotList(SlotsType.WithTokenPresent);
            if (slots == null || slots.Count == 0)
                throw new Exception("Nije pronađen nijedan PKCS#11 slot sa ubačenim tokenom.");

            // ✔ Koristimo prvi pronađeni slot (kartica)
            Slot slot = slots[0];

            // ✔ Otvori sesiju (read-write je obavezno za potpisivanje)
            _session = slot.OpenSession(SessionType.ReadWrite);

            // ✔ Unesi PIN
            string pin = PromptForPin(owner);
            if (string.IsNullOrEmpty(pin))
                throw new Exception("PIN nije unet.");

            // ✔ Login
            _session.Login(CKU.CKU_USER, pin);

            // ✔ Privatni ključ
            FindPrivateKey();

            // ✔ Sertifikat
            FindCertificate();
        }

        private string PromptForPin(IWin32Window owner)
        {
            using (PinPromptForm form = new PinPromptForm())
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.Pin;
            }
            return null;
        }

        private void FindPrivateKey()
        {
            // ✔ Priprema pretrage privatnog ključa
            List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
            searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, (ulong)CKO.CKO_PRIVATE_KEY));

            _session.FindObjectsInit(searchTemplate);
            List<ObjectHandle> found = _session.FindObjects(10);
            _session.FindObjectsFinal();

            if (found == null || found.Count == 0)
                throw new Exception("Privatni ključ nije pronađen na kartici.");

            _privateKeyHandle = found[0];
        }

        private void FindCertificate()
        {
            // ✔ Pretraga sertifikata (javnog ključa)
            List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
            searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, (ulong)CKO.CKO_CERTIFICATE));

            _session.FindObjectsInit(searchTemplate);
            List<ObjectHandle> foundCerts = _session.FindObjects(10);
            _session.FindObjectsFinal();

            if (foundCerts == null || foundCerts.Count == 0)
                throw new Exception("Sertifikat nije pronađen na kartici.");

            ObjectHandle certHandle = foundCerts[0];

            // ✔ Uzmemo CKA_VALUE (DER X.509 sertifikat)
            List<CKA> attributes = new List<CKA>();
            attributes.Add(CKA.CKA_VALUE);

            List<ObjectAttribute> certAttributes = _session.GetAttributeValue(certHandle, attributes);

            byte[] certData = certAttributes[0].GetValueAsByteArray();

            X509CertificateParser parser = new X509CertificateParser();
            _certificate = parser.ReadCertificate(certData);
        }

        public void Dispose()
        {
            try
            {
                if (_session != null)
                {
                    try { _session.Logout(); }
                    catch { }

                    _session.CloseSession();
                    _session.Dispose();
                    _session = null;
                }
            }
            catch { }

            try
            {
                if (_pkcs11 != null)
                {
                    _pkcs11.Dispose();
                    _pkcs11 = null;
                }
            }
            catch { }
        }
    }
}
