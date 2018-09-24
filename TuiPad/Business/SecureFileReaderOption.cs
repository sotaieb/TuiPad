using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TuiPad.Business
{
    public class SecureFileReaderOption : FileReaderOption
    {
        public IPrincipal Principal { get; protected set; }

        public SecureFileReaderOption(FileReader fileReader, IPrincipal principal) : base(fileReader)
        {
            this.FileReader = fileReader;
            this.Principal = principal;
        }
        public override string Read(string path)
        {
            if (Principal.IsInRole("admin"))
            {
                return FileReader.Read(path);
            }

            throw new Exception("Unauthorized !");
        }
    }
}
