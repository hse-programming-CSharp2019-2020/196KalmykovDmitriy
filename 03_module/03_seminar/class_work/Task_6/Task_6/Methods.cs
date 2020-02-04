using System;

namespace Task_6
{
    // Declare delegate.
    internal delegate void MethodsEvents();

    // Declare delegate.
    internal delegate void ItemEvents(int[,] arr);

    /// <summary>
    /// Class with methods.
    /// </summary>
    internal class Methods
    {
        public static int Sum;

        // Variable for random.
        private static readonly Random Rnd = new Random();

        // Events.
        internal static event MethodsEvents LineComplete;
        internal static event ItemEvents NewItemFilled;

        /// <summary>
        /// Print array.
        /// </summary>
        /// <param name="arr"> Array </param>
        internal static void PrintArray(int[,] arr)
        {
            Program.PrintMessage("Result array: \n");

            for (var i = 0; i < arr.GetUpperBound(0); i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    for (var k = 0; k < 5; k++)
                        Console.Write(arr[i, 5 * j + k] + " ");


                    // Raise event.
                    LineComplete?.Invoke();
                }
            }
        }

        /// <summary>
        /// Fill array.
        /// </summary>
        /// <param name="arr"> Array </param>
        internal static void FillArray(int[,] arr)
        {
            for (var i = 0; i <= arr.GetUpperBound(0); i++)
                for (var j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    arr[i, j] = Rnd.Next(100);

                    // Print message and raise event.
                    Program.PrintMessage($"New item added: {arr[i, j]}\n", ConsoleColor.Magenta);

                    NewItemFilled?.Invoke(arr);
                }
        }

        /// <summary>
        /// Find sum of elements.
        /// </summary>
        /// <param name="arr"> Array </param>
        internal static void ArraySumCount(int[,] arr)
        {
            Sum = 0;

            // Find sum.
            for (var i = 0; i <= arr.GetUpperBound(0); i++)
                for (var j = 0; j <= arr.GetUpperBound(1); j++)
                    Sum += arr[i, j];

            Program.PrintMessage($"Sum of elements of array: {Sum}\n");
        }
    }
}
