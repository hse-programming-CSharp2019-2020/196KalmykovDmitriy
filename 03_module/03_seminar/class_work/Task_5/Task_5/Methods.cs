using System;

namespace Task_5
{
    // Declare delegate.
    public delegate void LineCompleteEvent();


    /// <summary>
    /// Class methods.
    /// </summary>
    internal class Methods
    {
        // Event.
        public static event LineCompleteEvent LineComplete;
        /// <summary>
        /// Print array.
        /// </summary>
        /// <param name="arr"> Array </param>
        public static void PrintArray(int[,] arr)
        {
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
    }
}
