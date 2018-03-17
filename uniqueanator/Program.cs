using System;
using System.IO;

namespace uniqueanator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var files = Directory.EnumerateFiles(args[0]);

            foreach (var fileName in files)
            {
                var extensionStart = fileName.LastIndexOf(".", StringComparison.InvariantCulture);
                var extension = fileName.Substring(extensionStart, fileName.Length - extensionStart);
                var guid = Guid.NewGuid();
                Console.WriteLine($"Moving file {fileName} to File_{guid}{extension}" );
                File.Move(fileName, $"{args[0]}\\File_{guid}{extension}");                
                Console.WriteLine($"Finished with file {fileName}");
            }
            Console.WriteLine("Done");
        }
    }
}
