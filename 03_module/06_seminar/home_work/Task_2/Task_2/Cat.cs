using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    internal class Cat : Animal
    {
        // Constructor.
        public Cat(string name) : base(name)
        {
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        internal override void OnTrainingStartedHandler(object sender,
            TrainingEventArgs e)
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
                Console.WriteLine($"Cat {Name} does exercise #{numberExercise} Meow!");
                exercises.Add(numberExercise);
            }
        }
    }
}
