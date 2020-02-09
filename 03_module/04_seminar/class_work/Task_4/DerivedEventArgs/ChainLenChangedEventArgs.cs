using System;

namespace DerivedEventArgs
{
    public class ChainLenChangedEventArgs : EventArgs
    {
        // Radius.
        public double Rad { get; }
        public ChainLenChangedEventArgs(double r) => Rad = r;
    }
}
