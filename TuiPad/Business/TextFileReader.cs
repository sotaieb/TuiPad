using System.IO;

namespace TuiPad.Business
{
    public class TextFileReader : FileReader
    {
        public override string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }
    }
}
