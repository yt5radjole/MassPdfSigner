using System;
using iTextSharp.text.pdf.security;
using Net.Pkcs11Interop.HighLevelAPI;
using Net.Pkcs11Interop.Common;

namespace MassPdfSigner
{
    public class Pkcs11ExternalSignature : IExternalSignature
    {
        private readonly Session _session;
        private readonly ObjectHandle _privateKey;

        public Pkcs11ExternalSignature(Session session, ObjectHandle privateKey)
        {
            _session = session;
            _privateKey = privateKey;
        }

        // iText ne sme da radi hash – token radi sve
        public string GetHashAlgorithm()
        {
            return "SHA-256";
        }

        public string GetEncryptionAlgorithm()
        {
            return "RSA";
        }

        // Tokenu se šalje RAW data, token radi SHA256 + RSA_PKCS
        public byte[] Sign(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            // Token radi SHA256 + RSA_PKCS
            Mechanism mech = new Mechanism(CKM.CKM_SHA256_RSA_PKCS);

            // Data = RAW PDF byte range pre signature placeholder
            byte[] signature = _session.Sign(mech, _privateKey, data);

            return signature;
        }
    }
}
