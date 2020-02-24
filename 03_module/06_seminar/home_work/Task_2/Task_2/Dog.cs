using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    internal class Dog : Animal
    {
        // Constructor.
        public Dog(string name) : base(name)
        {
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        internal override void OnTrainingStartedHandler(object sender, TrainingEventArgs e)
        {
            // Auxiliary array from used numbers of exercises.
            var exercises = new List<int>(e.Amount);

            for (var i = 0; i < e.Amount; i++)
            {
                var numberExercise = e.Number;

                // Check this exercise.
                if (exercises.Any(el => el == numberExercise))
                {
                    i--;
                    continue;
                }

                // If this exercise was not.
                Console.WriteLine($"Dog {Name} does exercise #{numberExercise}: Aw-aw!");
                exercises.Add(numberExercise);
            }
        }
    }
}
