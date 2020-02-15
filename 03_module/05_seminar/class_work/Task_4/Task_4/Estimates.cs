using System;

namespace Task_4
{
    internal class Estimates
    {
        // Amount of numbers.
        internal double Numb;

        // Sum of numbers.
        private double _sumX;

        // Sum of square of numbers.
        private double _sumX2;

        // Min value.
        internal double Xmin { get; set; } = double.MaxValue;

        // Max value.
        internal double Xmax { get; set; } = double.MinValue;

        // Average value.
        internal double Average => _sumX / Numb;

        internal double Deviation;

        /// <summary>
        /// Add new value.
        /// </summary>
        /// <param name="newValue"> Value </param>
        public void Add(double newValue)
        {
            // Change value of variables.
            Numb++;
            _sumX += newValue;
            _sumX2 += Math.Pow(newValue, 2);

            if (newValue > Xmax)
                Xmax = newValue;

            if (newValue < Xmin)
                Xmin = newValue;

            Deviation = Math.Sqrt(_sumX2 / (Numb - 1) - _sumX * _sumX / (Numb - 1) / Numb);
        }
    }
}
