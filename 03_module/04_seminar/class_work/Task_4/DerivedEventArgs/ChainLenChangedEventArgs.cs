using System;

namespace DerivedEventArgs
{
    /// <summary>
    /// Class my Event args.
    /// </summary>
    public class ChainLenChangedEventArgs : EventArgs
    {
        // Radius.
        public double Rad { get; }

        // Constructor.
        public ChainLenChangedEventArgs(double r) => Rad = r;
    }
}
