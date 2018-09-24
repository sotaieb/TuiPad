using System;
using System.IO;
using System.Reflection;
using TuiPad.Business;
using Xunit;
using Xunit.Abstractions;

namespace TuiPad.Tests
{
    public class ProgramTests
    {
        private readonly ITestOutputHelper _output;
        private readonly string _currentPath;

        public ProgramTests(ITestOutputHelper output)
        {
            this._output = output;
            _currentPath = Path.GetDirectoryName(typeof(ProgramTests)
                .GetTypeInfo().Assembly.Location);
        }

        [Fact]
        public void Read_Text_File_Text()
        {
            var reader = new TextFileReader();
            var result = reader.Read($"{_currentPath}\\textfile.txt");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }

        [Fact]
        public void Read_Xml_File_Text()
        {
            var reader = new XmlFileReader();
            var result = reader.Read($"{_currentPath}\\xmlfile.xml");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }

        [Fact]
        public void Read_Encrypted_File_Text()
        {
            var reader = new EncryptedFileReaderOption(new TextFileReader(), "Reverse");
            var result = reader.Read($"{_currentPath}\\encryptedtextfile.txt");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }
    }
}
