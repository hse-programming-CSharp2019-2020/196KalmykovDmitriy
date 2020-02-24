using System;

namespace Task_2
{
    internal class AnimalTrainer
    {
        // Event training started.
        internal event EventHandler<TrainingEventArgs> BeginTrainingEvent;

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="amount"></param>
        internal void LetsGoTraining(int amount) =>
        BeginTrainingEvent?.Invoke(this,
            new TrainingEventArgs(amount));
    }
}
