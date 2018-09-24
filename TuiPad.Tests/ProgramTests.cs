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
    }
}
