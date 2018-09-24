using System;
using System.Collections.Generic;
using System.Text;

namespace TuiPad.Business
{
    public class FileReaderOption : FileReader
    {
        public FileReader FileReader { get; set; }
        public FileReaderOption(FileReader fileReader)
        {
            this.FileReader = fileReader;
        }
        public override string Read(string path)
        {
            return FileReader.Read(path);
        }
    }
}
