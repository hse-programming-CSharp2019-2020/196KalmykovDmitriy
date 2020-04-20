using System;

namespace Variant_1
{
    [Serializable]
    public class Contest : ControlElement
    {
        public int TasksNumber;

        public Contest() { }
        
        /// <summary>
        /// Check bounds of tasks.
        /// </summary>
        /// <param name="tasksNumber"> Amount of tasks </param>
        /// <returns> True or false </returns>
        private bool IsCorrectValue(int tasksNumber) =>
            tasksNumber >= 1 && tasksNumber <= 10;

        internal Contest(int weight, string name, int tasksNumber) : base(weight, name)
        {
            if (!IsCorrectValue(tasksNumber))
                throw new ArgumentOutOfRangeException();

            TasksNumber = tasksNumber;
        }

        /// <summary>
        /// Return info about contest.
        /// </summary>
        /// <returns> Info about contest </returns>
        public override string ToString() =>
             $"Contest {TasksNumber}" + base.ToString();
    }
}
