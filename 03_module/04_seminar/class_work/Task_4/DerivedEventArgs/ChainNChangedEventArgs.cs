using System;

namespace DerivedEventArgs
{
    public class ChainNChangedEventArgs : EventArgs
    {
        public int N { get; }
        public double Len { get; }

        public ChainNChangedEventArgs(int n, double len) =>
                (N, Len) = (n, len);
    }
}
