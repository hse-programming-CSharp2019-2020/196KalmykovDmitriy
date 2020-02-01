using System;

namespace Task_4
{
    /// <summary>
    /// Class ConsoleUI for connection with user.
    /// </summary>
    internal class ConsoleUI
    {
        // Event.
        internal event NewStringValue NewStringValueHappened;

        // Property.
        internal UIString S { get; set; } = new UIString();

        /// <summary>
        /// Get string from user.
        /// </summary>
        internal void GetStringFromUI()
        {
            Program.PrintMessage("Enter new string: ");
            NewStringValueHappened(Console.ReadLine());
            RefreshUI();
        }

        /// <summary>
        /// Add method to the event.
        /// </summary>
        internal void CreateUI()
        {
            RefreshUI();
            NewStringValueHappened += S.NewStringValueHappenedHandler;
        }

        /// <summary>
        /// Clear console and print result.
        /// </summary>
        private void RefreshUI()
        {
            Console.Clear();
            Console.Write("String text: ");
            Program.PrintMessage(S.Str + Environment.NewLine, ConsoleColor.Yellow);
        }
    }
}
