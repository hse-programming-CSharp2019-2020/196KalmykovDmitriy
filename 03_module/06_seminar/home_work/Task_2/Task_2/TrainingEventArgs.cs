using System;

namespace Task_2
{
    /// <summary>
    /// My EventArgs.
    /// </summary>
    internal class TrainingEventArgs : EventArgs
    {
        private static readonly Random Rnd = new Random();

        // Number of exercise.
        internal int Number => Rnd.Next(1, 11);

        // Amount of exercises.
        internal int Amount { get; }

        // Constructor.
        internal TrainingEventArgs(int amount) => Amount = amount;
    }
}
