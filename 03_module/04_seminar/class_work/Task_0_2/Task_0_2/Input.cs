using System;

namespace Task_0_2
{
    // My delegate.
    internal delegate void Del(string el1, ConsoleColor el2);
    internal class Input
    {
        // Event.
        internal event Del UserInput = EventGuide2.PrintMessage;

        /// <summary>
        /// Method for get string from user.
        /// </summary>
        internal void GetUserInput()
        {
            while (true)
            {
                Console.WriteLine("Type any characters or 'q' to quit end press Enter.");

                // Raise event.
                UserInput?.Invoke(Console.ReadLine(), ConsoleColor.Magenta);
            }
        }
    }
}
