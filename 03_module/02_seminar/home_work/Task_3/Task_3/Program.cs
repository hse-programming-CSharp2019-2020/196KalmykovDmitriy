using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        private static readonly Random rnd = new Random();
        private const int SizeArr = 10;
        private const int MinValue = -3;
        private const int MaxValue = 3;

        private static double GetDoubleFromInterval() =>
            MinValue + double.Epsilon + rnd.NextDouble() * (MaxValue - MinValue - double.Epsilon);




        private static double[] GetDoubleArr()
        {
            var tempArr = new double[SizeArr];

            for (int i = 0; i < SizeArr; i++)
                tempArr[i] = GetDoubleFromInterval();

            return tempArr;

        }

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                var A = GetDoubleArr();

                var B = Array.ConvertAll(A, delegate (double el) { return el >= 0 ? (int)el : 0; });

                PrintMessage("Массив А: ");
                Array.ForEach(A, el => Console.Write($"{el:0.##} "));
                Console.WriteLine();

                PrintMessage("Массив B: ");
                Array.ForEach(B, el => Console.Write(el + " "));
                Console.WriteLine();

                PrintMessage("Print ESC for exit, " +
                             "press any other any key for repeat solution", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
