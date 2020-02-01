using System;

namespace Task_2
{
    /// <summary>
    /// Class subscriber2.
    /// </summary>
    internal class SomethingHappenedSubscriber2
    {
        /// <summary>
        /// Print message.
        /// </summary>
        internal void SomethingHappenedHandler() =>
            Console.WriteLine("Second subscriber has handled an event");
    }
}
