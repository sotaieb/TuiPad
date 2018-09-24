using System.IO;
using System.Xml.Linq;

namespace TuiPad.Business
{
    public class XmlFileReader : FileReader
    {
        public override string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (!File.Exists(path))
                return null;

            var xml = XDocument.Load(path);
            return xml.ToString();
        }
    }
}
