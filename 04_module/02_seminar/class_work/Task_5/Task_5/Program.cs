using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Task_5;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"colors.json";
            string outputPath = @"newColors.json";

            List<MyColor> colors = ParseColors(inputPath);

            Console.WriteLine("\tCOLORS:");
            foreach (var item in colors)
                Console.WriteLine(item);

            JsonSerializationAsync(outputPath, colors);
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        static void JsonSerializationAsync(string path, List<MyColor> colors)
        {
            try
            {
                // Serialization
                using (FileStream fs = new FileStream("test2339.txt", FileMode.Create))
                {
                    JsonSerializer.SerializeAsync(fs, colors);
                }
                Console.WriteLine("\nObjects were successfully serialized");
            }
            catch (IOException e)
            {
                Console.WriteLine("Writing objects in file exception: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Serialization exception");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Parsing file's info method
        /// </summary>
        /// <param name="path">File's path</param>
        /// <returns>List of colors</returns>
        static List<MyColor> ParseColors(string path)
        {
            List<MyColor> colors = new List<MyColor>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Checking if it is first or last line with brackets
                        if (line == "{" || line == "}")
                            continue;

                        // Getting color's name
                        string name = line.Substring(line.IndexOf('"') + 1, line.IndexOf(':') - 3);
                        name = name.Trim('"');

                        line = line.Remove(0, line.IndexOf('['));
                        line = line.Trim('[', ']', ',');

                        // Getting RGB and alpha values
                        var numbers = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        colors.Add(new MyColor(
                            name,
                            byte.Parse(numbers[0]),
                            byte.Parse(numbers[1]),
                            byte.Parse(numbers[2]),
                            byte.Parse(numbers[3])
                            )
                        );
                    }
                }

                return colors;
            }
            catch (IOException e)
            {
                Console.WriteLine("File reading exception: " + e.Message);
                return colors;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while parsing: " + e.Message);
                return colors;
            }
        }
    }
}