using System;

namespace MyLib
{
    // Declare delegats.
    public delegate int[] Func1(int val);

    public delegate void Func2(int[] arrInts);

    /// <summary>
    /// Class for work with number.
    /// </summary>
    public class Methods_Lib
    {
        public static int[] GetArray(int val)
        {
            int counter = 0;

            // Create array.
            // Array's length = length of number.
            int[] arrInts = new int[(int)Math.Log10(val) + 1];

            // Fill array.
            while (val > 0)
            {
                arrInts[counter] = val % 10;
                val /= 10;
                counter++;
            }

            Array.Reverse(arrInts);

            return arrInts;
        }

        /// <summary>
        /// Method for print array.
        /// </summary>
        /// <param name="arr"> Array for print </param>
        public static void PrintArray(int[] arr) =>
            Array.ForEach(arr, val => Console.Write(val + " "));
    }
}