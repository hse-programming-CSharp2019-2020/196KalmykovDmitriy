using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class MyColor
    {
        private string color;
        private byte R, G, B;

        internal MyColor(string color, byte R, byte G, byte B)
        {
            this.color = color;
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public override string ToString() =>
         $"Color = {color}, R= {R}, G = {G}, B = {B}";
    }

    internal class Program
    {
        private static MyColor[] GetArray(string[] lines)
        {
            var myColors = new MyColor[lines.Length - 2];

            for (var i = 1; i < lines.Length - 1; i++)
            {
                var colorName = lines[i].Split(':')[0];

                var index = lines[i].IndexOf('#');
                var colorR = lines[i].Substring(index + 1, 2);
                var colorG = lines[i].Substring(index + 1, 2);
                var colorB = lines[i].Substring(index + 1, 2);

                myColors[i - 1] = new MyColor
                (
                    colorName,
                    Convert.ToByte(colorR, 16),
                    Convert.ToByte(colorG, 16),
                    Convert.ToByte(colorB, 16)
                );
            }

            return myColors;
        }

        private static void JsonSerialize(MyColor[] myColors)
        {
            using (var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new DataContractJsonSerializer(typeof(MyColor[]));

                formatter.WriteObject(fs, myColors);
            }
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}css-color-names.json";

            var lines = File.ReadAllLines(path);

            var myColors = GetArray(lines);

            JsonSerialize(myColors);

            foreach (var color in myColors)
            {
                Console.WriteLine(color);
            }

            Console.ReadLine();
        }
    }
}
