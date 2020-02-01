using System;

namespace Task_2
{
    // Declare delegate.
    internal delegate void EventHandler();

    /// <summary>
    /// Class source.
    /// </summary>
    internal class Publisher
    {
        // Event.
        internal event EventHandler SomethingHappened;

        /// <summary>
        /// Raise event.
        /// </summary>
        internal void FireEvent()
        {
            Console.WriteLine("Fire SomethingHappened!!!");
            SomethingHappened?.Invoke();
        }
    }
}
