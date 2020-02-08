using System;

namespace Task_3
{
    /// <summary>
    /// Class bead.
    /// </summary>
    internal class Bead
    {

        // radius.
        private double _r;

        // Property for radius.
        internal double R
        {
            set => _r = value;
            get => _r;
        }

        // Constructor.
        internal Bead(double r)
        {
            if (r <= 0)
                throw new ArgumentOutOfRangeException("Radius must be >= 0");

            _r = r;
        }

        /// <summary>
        /// Change radius, because of amount of beads has changed.
        /// </summary>
        /// <param name="amount"> Amount of beads </param>
        /// <param name="len"> Length of chain </param>
        internal void ChangeN(int amount, double len) =>
            _r = len / amount;
    }
}
