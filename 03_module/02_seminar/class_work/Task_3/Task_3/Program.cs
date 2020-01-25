using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Numerical;

namespace Task_3
{
    class Program
    {
        #region consts for bisection method
        private const double epsX = 0.01;
        private const double epsY = 0;
        private const double left = 3;
        private const double right = 4;
        #endregion

        #region consts for optimum method
        private const double epsilon = 0.01; //y
        private const double delta = 0.001;//x
        #endregion

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static double SinX(double x) => Math.Sin(x);

        private static void TestBisec()
        {
            PrintMessage("Тест метода Bisec:\n\n", ConsoleColor.Green);

            Console.WriteLine("Найдём корень уравнения Sin(x) = 0," +
                              $" на отрезке [{left}, {right}]:" + Environment.NewLine);

            function[] funcs =
            {
                Math.Sin,
                SinX,
                delegate(double x) { return Math.Sin(x); },
                x => Math.Sin(x)
            };

            string[] messages =
            {
                "Поиск корня с использованием библиотечной функции:",
                "Поиск корня с использованием статического метода, явно определённого в программе: ",
                "Поиск корня с использованием анонимного метода: ",
                "Поиск корня с использованием лямбда-выражения: "
            };

            for (int i = 0; i < 4; i++)
            {
                PrintMessage(messages[i]);
                PrintMessage($"x = {NumMeth.Bisec(left, right, epsX, epsY, funcs[i])}\n",
                    ConsoleColor.Yellow);
            }

            Console.WriteLine();
        }

        private static void TestOptimum()
        {
            PrintMessage("Тест метода Optimum_1:\n\n", ConsoleColor.Green);

            double minX;

            string[] funcsText =
            {
                "Cos(x)",
                "x * (x * x - 2) - 5",
                "-Sin(x) - Sin(3 * x) / 3"
            };

            Functional_1[] funcs =
            {
                x => Math.Cos(x),
                x => x * (x * x - 2) - 5,
                x => -Math.Sin(x) - Math.Sin(3 * x) / 3
            };

            (int left, int right)[] bounds =
            {
                (3, 6),
                (0, 1),
                (0, 1)
            };

            for (int i = 0; i < 3; i++)
            {
                minX = NumMeth.Optimum_1(funcs[i], bounds[i].left, bounds[i].right, delta, epsilon);

                PrintMessage($"Точка минимума функции {funcsText[i]} " +
                             $"на отрезке [{bounds[i].left}, {bounds[i].right}]: ");
                PrintMessage($"x = {minX}\n", ConsoleColor.Yellow);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                TestBisec();
            }
            catch (IndexOutOfRangeException ex)
            {
                PrintMessage(ex.Message, ConsoleColor.Red);
            }

            TestOptimum();
        }
    }
}
