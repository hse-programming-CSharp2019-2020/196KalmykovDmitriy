using System;
using System.Collections.Generic;

namespace Task_3_Form
{
    class Bead
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
        /// <param name="beads"> List of beads </param>
        internal void ChangeN(int amount, double len, List<Bead> beads)
        {
            foreach (var bead in beads)
            {
                bead.R = len / amount;
            }
            _r = len / amount;
        }
    }
}
