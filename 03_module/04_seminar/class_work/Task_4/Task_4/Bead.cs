using DerivedEventArgs;
using System;

namespace Task_4
{
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
        /// Change N.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public void OnChainLenChangedHandler(object sender,
            ChainNChangedEventArgs e) =>
            _r = e.Len / e.N;
    }
}
