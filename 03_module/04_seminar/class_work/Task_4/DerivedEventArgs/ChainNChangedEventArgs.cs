using System;

namespace DerivedEventArgs
{
    /// <summary>
    /// Class  my Event args.
    /// </summary>
    public class ChainNChangedEventArgs : EventArgs
    {
        // Amount of beads.
        public int N { get; }

        // Length of chain.
        public double Len { get; }

        // Constructor.
        public ChainNChangedEventArgs(int n, double len) =>
                (N, Len) = (n, len);
    }
}