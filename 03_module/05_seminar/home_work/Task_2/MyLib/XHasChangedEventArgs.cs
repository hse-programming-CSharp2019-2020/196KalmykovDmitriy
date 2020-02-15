using System;

namespace MyLib
{
    /// <summary>
    /// My EventArgs.
    /// </summary>
    public class XHasChangedEventArgs : EventArgs
    {
        // New value of X.
        public double NewX { get; }

        // Constructor.
        public XHasChangedEventArgs(double newX) => NewX = newX;
    }
}
