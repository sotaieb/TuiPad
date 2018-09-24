using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

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
            if (string.IsNullOrEmpty(path))
                return null;

            if (!File.Exists(path))
                return null;

            // when file is encrypted, read file as text file
            // then decrypt content
            // then parse decrypted content
            var encrypted = File.ReadAllText(path);
                
            if (EncryptionAlgorythm.Equals("Reverse"))
            {
                var decrypted = new String(encrypted.Reverse().ToArray());
                if (FileReader is XmlFileReader)
                {
                    var xml = XDocument.Parse(decrypted);
                    decrypted = xml.ToString();
                }
                return decrypted;
                
            }

            throw new Exception("Invalid encryption algorithm.");
        }
    }
}
