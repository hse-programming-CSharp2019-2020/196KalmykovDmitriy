using System;

namespace Task_2
{
    /// <summary>
    /// Class subscriber1.
    /// </summary>
    internal class SomethingHappenedSubscriber
    {
        /// <summary>
        /// Print message.
        /// </summary>
        public void SomethingHappenedHandler() =>
            Console.WriteLine("First subscriber has handled an event");
    }
}
