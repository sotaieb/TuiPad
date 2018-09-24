using System.Security.Principal;

namespace TuiPad.Business
{
    public class FileReaderBuilder
    {
        public FileReader FileReader { get; set; }
        public FileReaderBuilder(FileReader fileReader)
        {
            FileReader = fileReader;
        }

        public void WithSecurity(IPrincipal principal)
        {
            FileReader = new SecureFileReaderOption(FileReader, principal);
        }

        public void WithEncryption(string algorithm)
        {
            FileReader = new EncryptedFileReaderOption(FileReader, algorithm);
        }

        public FileReader Build()
        {
            return FileReader;
        }

    }
}
