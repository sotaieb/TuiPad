using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TuiPad.Business
{
    public class JsonFileReader : FileReader
    {
        public override string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (!File.Exists(path))
                return null;

            var content = File.ReadAllText(path);
            var formatted = JValue.Parse(content).ToString(Formatting.Indented);
            
            return formatted;
        }
    }
}
