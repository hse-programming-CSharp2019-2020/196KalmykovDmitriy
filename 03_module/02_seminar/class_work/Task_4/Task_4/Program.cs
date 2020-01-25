using System;

namespace Task_4
{
    class Program
    {
        // Как альтернатива, первые 2 сортировки можно было бы расписать в 3 случая,
        // но удобней использовать CompareTo.
        /// <summary>
        /// Method for sort.
        /// </summary>
        /// <param name="x"> First value in couple </param>
        /// <param name="y"> Second value in couple </param>
        /// <returns> 1, 0, or -1 </returns>
        private static int AscendingSort(int x, int y) =>
             x.CompareTo(y);

        /// <summary>
        /// Method for sort.
        /// </summary>
        /// <param name="x"> First value in couple </param>
        /// <param name="y"> Second value in couple </param>
        /// <returns> 1, 0, or -1 </returns>
        private static int DescendingSort(int x, int y) =>
            y.CompareTo(x);

        /// <summary>
        /// Method for sort.
        /// </summary>
        /// <param name="x"> First value in couple </param>
        /// <param name="y"> Second value in couple </param>
        /// <returns> 1, 0, or -1 </returns>
        private static int ParitySort(int x, int y)
        {
            // Swap.
            if (x % 2 == 1 && y % 2 == 0)
                return 1;

            if (x % 2 == y % 2)
                return 0;

            return -1;
        }

        /// <summary>
        /// Method for sort.
        /// </summary>
        /// <param name="x"> First value in couple </param>
        /// <param name="y"> Second value in couple </param>
        /// <returns> 1, 0, or -1 </returns>
        private static int OddSort(int x, int y)
        {
            // Swap.
            if (x % 2 == 0 && y % 2 == 1)
                return 1;

            if (x % 2 == y % 2)
                return 0;

            return -1;
        }

        /// <summary>
        /// Print array.
        /// </summary>
        /// <param name="series"> Series </param>
        private static void PrintArray(Series series)
        {
            // Set text color.
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in series.intsArr)
                Console.Write(item + " ");

            Console.ResetColor();
            Console.WriteLine();
        }

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
        /// Print sorted arrays.
        /// </summary>
        /// <param name="series"> Series </param>
        private static void PrintSortedArrays(Series series)
        {
            // Types of sorting.
            Comparison<int>[] typesOfSort =
            {
                AscendingSort,
                DescendingSort,
                ParitySort,
                OddSort
            };

            // Help messages.
            string[] messages =
            {
                "Sorted in increasing order: ",
                "Sorted in decreasing order: ",
                "Sorted by parity: ",
                "Sorted by oddness: "
            };

            // Print info.
            for (int i = 0; i < 4; i++)
            {
                PrintMessage(messages[i]);
                series.Order(typesOfSort[i]);
                PrintArray(series);
            }
        }

        static void Main(string[] args)
        {
            var series = new Series { intsArr = new[] { 5, 3, 1, 42, 21, 6, 8, 42, 27, 13 } };

            // Print info about array.
            PrintMessage("Initial array: ");
            PrintArray(series);
            Console.WriteLine();

            PrintSortedArrays(series);

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}