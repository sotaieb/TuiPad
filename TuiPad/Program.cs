using System;
using System.IO;
using System.Linq;
using TuiPad.Business;

namespace TuiPad
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"*T*U*I*P*A*D*");

                //  Ask for file type.
                Console.WriteLine($"Which file type you want to read (text, xml, json)?");
                var fileType = Console.ReadLine();

                if (!new string[] { "text", "xml", "json" }.Contains(fileType.ToLower()))
                {
                    Console.WriteLine("ERROR : Invalid file type.");
                    Console.ReadKey();
                    continue;
                }

                // Ask for using encryption system.
                Console.WriteLine($"Use encryption file system (true, false)?");
                if (!bool.TryParse(Console.ReadLine(), out bool withEncryption))
                {
                    Console.WriteLine("ERROR : Possible value : 'true' or 'false'");
                    Console.ReadKey();
                    continue;
                }

                // If encryption exists, ask for algorithm.
                var algorithm = string.Empty;
                if (withEncryption)
                {
                    Console.WriteLine($"What algorithm should we use (reverse)?");
                    algorithm = Console.ReadLine();


                    if (string.IsNullOrEmpty(algorithm))
                    {
                        Console.WriteLine("ERROR : Algorithm is required.");
                        Console.ReadKey();
                        continue;
                    }

                    if (!new string[] { "reverse" }.Contains(algorithm.ToLower()))
                    {
                        Console.WriteLine("ERROR : Invalid algorithm.");
                        Console.ReadKey();
                        continue;
                    }

                }

                // Ask for using security system.
                Console.WriteLine($"Use security context (true, false)?");
                if (!bool.TryParse(Console.ReadLine(), out bool withSecurity))
                {
                    Console.WriteLine("ERROR : Possible value : 'true' or 'false'");
                    Console.ReadKey();
                    continue;
                }

                // If security context enabled, ask for role.
                var role = string.Empty;
                if (withSecurity)
                {
                    Console.WriteLine($"What is your role (admin, user)?");
                    role = Console.ReadLine();

                    if (string.IsNullOrEmpty(role))
                    {
                        Console.WriteLine("ERROR : Role is required.");
                        Console.ReadKey();
                        continue;
                    }

                    if (!new string[] { "admin", "user" }.Contains(role.ToLower()))
                    {
                        Console.WriteLine("ERROR : Invalid Role.");
                        Console.ReadKey();
                        continue;
                    }

                }

                //  Ask for file path.
                Console.WriteLine($"Where is your file ?");
                var filePath = Console.ReadLine();

                if (string.IsNullOrEmpty(filePath))
                {
                    Console.WriteLine("ERROR : File path is required.");
                    Console.ReadKey();
                    continue;
                }

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("ERROR : Invalid file path.");
                    Console.ReadKey();
                    continue;
                }
                try
                {
                    ProcessFile(filePath, fileType, withEncryption, algorithm, withSecurity, role);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               

                Console.WriteLine("Press any key ton continue...");
                Console.ReadKey();
            }

        }

        private static void ProcessFile(string filePath, string fileType,
            bool withEncryption = false, string algorithm = null,
            bool withSecurity = false, string role = null)
        {

            FileReader fileReader = null;

            switch (fileType)
            {
                case "text":
                    fileReader = new TextFileReader();
                    break;
                case "xml":
                    fileReader = new XmlFileReader();
                    break;
                case "json":
                    fileReader = new JsonFileReader();
                    break;
            }

            var builder = new FileReaderBuilder(fileReader);

            if (withEncryption)
            {
                switch (algorithm)
                {
                    case "reverse":
                        builder.WithEncryption("reverse");
                        break;
                }

            }

            if (withSecurity)
            {
                switch (role)
                {
                    case "admin":
                        var adminIdentity = new Identity("admin");
                        var adminPrincipal = new Principal(adminIdentity);
                        builder.WithSecurity(adminPrincipal);
                        break;
                    case "user":
                        var userIdentity = new Identity("user");
                        var userPrincipal = new Principal(userIdentity);
                        builder.WithSecurity(userPrincipal);
                        break;
                }
            }

            var reader = builder.Build();
            var content = reader.Read(filePath);
            Console.WriteLine($"{content}");

        }

    }
}
