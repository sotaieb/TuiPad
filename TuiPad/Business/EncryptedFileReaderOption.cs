using System;
using System.Linq;

namespace TuiPad.Business
{
    public class EncryptedFileReaderOption : FileReaderOption
    {
        public string EncryptionAlgorythm { get; protected set; }

        public EncryptedFileReaderOption(FileReader FileReader, string encryptionAlgorythm) : base(FileReader)
        {
            this.EncryptionAlgorythm = encryptionAlgorythm;
        }

        public override string Read(string path)
        {
            var encrypted = base.Read(path);

            if (EncryptionAlgorythm.Equals("Reverse"))
            {
                var decrypted = new String(encrypted.Reverse().ToArray());
                return decrypted;
            }

            throw new Exception("Invalid encryption algorithm.");
        }
    }
}
