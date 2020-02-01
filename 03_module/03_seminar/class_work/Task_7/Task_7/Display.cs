using System;

namespace Task_7
{
    /// <summary>
    /// Class display.
    /// </summary>
    internal class Display
    {
        private const int Len = 30;
        private static string _str;

        /// <summary>
        /// Show bar.
        /// </summary>
        internal static void ShowBar(long n, int si, int kl)
        {
            var pos = Math.Abs((int)((double)kl / si * Len));

            // Create nice string.
            var s1 = new string('\u258c', pos);
            var s2 = new string('-', Len - pos - 1) + '\u25c4';

            _str = s1 + '\u258c' + s2;

            // Print that string.
            Program.PrintMessage("\r\t\t" + _str, ConsoleColor.Green);
        }
    }
}
