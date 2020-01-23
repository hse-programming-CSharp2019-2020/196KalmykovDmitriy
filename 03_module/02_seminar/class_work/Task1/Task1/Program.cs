using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Task1
{
    class Program
    {
        public static string RemoveDigits(string str) =>
            new string(str.Where(el => !char.IsDigit(el)).ToArray());

        public static string RemoveSpaces(string str) =>
            new string(str.Where(el => el != ' ').ToArray());

        static void Main(string[] args)
        {
            ConvertRule crBoth, 
                crMethod2 = RemoveSpaces, 
                crMethod1 = RemoveDigits;

            var conv = new Converter();

            string[] stringsForTest = { "as2 d 3q2w2 ass ", "a    s2d ", "12qwd vwwqe2 cw3d " };

            Array.ForEach(stringsForTest,
                el => Console.WriteLine($"Исходная строка: {el}"));

            Console.WriteLine();

            foreach (var el in stringsForTest)
                Console.WriteLine("Строка после удаления цифр: " +
                                  conv.Convert(el, crMethod1));

            Console.WriteLine();

            foreach (var el in stringsForTest)
                Console.WriteLine("Строка после удаления пробелов: " +
                                  conv.Convert(el, crMethod2));

            crBoth = crMethod1 + crMethod2;

            Console.WriteLine();

            foreach (var el in stringsForTest)
                Console.WriteLine(conv.Convert(el, crBoth));

            Console.ReadLine();
        }
    }
}