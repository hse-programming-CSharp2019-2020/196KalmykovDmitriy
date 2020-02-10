using System;

namespace Task_0_1
{
    internal class Publisher
    {
        // Delegate.
        internal delegate void Notify(string message);

        // Events.
        internal event Notify BeginOutput;
        internal event Notify EndOutput;

        /// <summary>
        /// Display message.
        /// </summary>
        /// <param name="message"> Message </param>
        internal void Display(string message)
        {
            OnBeginOutput();
            Console.WriteLine(message);
            OnEndOutput();
        }

        /// <summary>
        /// Help method 1.
        /// </summary>
        private void OnBeginOutput() =>
            BeginOutput?.Invoke("Starting output");

        /// <summary>
        /// Help method 2.
        /// </summary>
        private void OnEndOutput() =>
            EndOutput?.Invoke("Ending output");
    }
}
