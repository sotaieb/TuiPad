using System;
using System.IO;
using System.Linq;
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

        [Fact]
        public void Read_Xml_File_With_Admin_Security_Context()
        {
            var identity = new Identity("admin");
            var principal = new Principal(identity);

            var reader = new SecureFileReaderOption(new XmlFileReader(), principal);
            var result = reader.Read($"{_currentPath}\\xmlfile.xml");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }

        [Fact]
        public void Read_Xml_File_With_User_Security_Context_Throws_Exception()
        {
            var identity = new Identity("user");
            var principal = new Principal(identity);

            var reader = new SecureFileReaderOption(new XmlFileReader(), principal);
            
            Assert.Throws<Exception>(() => reader.Read($"{_currentPath}\\xmlfile.xml"));
        }

        [Fact]
        public void Read_Encrypted_File_Xml()
        {
            var reader = new EncryptedFileReaderOption(new XmlFileReader(), "Reverse");
            var result = reader.Read($"{_currentPath}\\encryptedxmlfile.xml");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }

        [Fact]
        public void ReverseText() {
            var encrypted = ">egassem/<.olleh>egassem<";

            var decrypted = new String(encrypted.Reverse().ToArray());
            _output.WriteLine(decrypted);
        }

        [Fact]
        public void Read_Text_File_With_Admin_Security_Context()
        {
            var identity = new Identity("admin");
            var principal = new Principal(identity);

            var reader = new SecureFileReaderOption(new TextFileReader(), principal);
            var result = reader.Read($"{_currentPath}\\textfile.txt");

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            _output.WriteLine(result);
        }

        [Fact]
        public void Read_Text_File_With_User_Security_Context_Throws_Exception()
        {
            var identity = new Identity("user");
            var principal = new Principal(identity);

            var reader = new SecureFileReaderOption(new TextFileReader(), principal);

            Assert.Throws<Exception>(() => reader.Read($"{_currentPath}\\textfile.txt"));
        }

    }
}
