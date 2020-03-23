using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_4
{
    internal class Program
    {
        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Checking signature at the beginning of file.
        /// </summary>
        /// <param name="file"> File </param>
        /// <param name="signature"> Signature </param>
        /// <returns> True - the signature is in the file, false - in other case </returns>
        private static bool HasSignature(IReadOnlyList<byte> file,
            IReadOnlyCollection<byte> signature)
        {
            return (signature.Count <= file.Count) &&
                  (!signature.Where((el, fileIndex) => el != file[fileIndex]).Any());
        }

        /// <summary>
        /// Analyze the signatures of all files from
        /// the dir folder and display the result.
        /// </summary>
        /// <param name="dir"> Folder </param>
        private static void AnalyzeDirectoryFiles(string dir)
        {
            try
            {
                var files = Directory.GetFiles(dir);

                Console.WriteLine($"Analyzing files in {dir} folder:\n");

                foreach (var fileName in files)
                {
                    var fileType = "unknown";
                    byte[] file = File.ReadAllBytes(fileName);

                    _ = HasSignature(file, new byte[] { 0x47, 0x49, 0x46, 0x38 })
                        ? fileType = "GIF"
                        : HasSignature(file, new byte[] { 0x25, 0x50, 0x44, 0x46 })
                            ? fileType = "PDF"
                            : HasSignature(file, new byte[] { 0x89, 0x50, 0x4E, 0x47,
                                                                       0x0D, 0x0A, 0x1A, 0x0A })
                                ? fileType = "PNG"
                                : HasSignature(file, new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 })
                                    ? fileType = "JPEG"
                                    : HasSignature(file, new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 })
                                        ? fileType = "Digital camera JPG(EXIF)"
                                        : "_";

                    Console.WriteLine($"{fileName} - {fileType} file\n");
                }
                Console.WriteLine($"Completed ({files.Length} file(s) analyzed)!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }

        private static void Main(string[] args)
        {
            string dir = args.Length > 0
                            ? args[0]
                            : Environment.CurrentDirectory;

            AnalyzeDirectoryFiles(dir);

            PrintMessage("\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
