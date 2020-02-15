using System;

namespace MyLib
{
    /// <summary>
    /// My EventArgs.
    /// </summary>
    public class YHasChangedEventArgs : EventArgs
    {
        // New value of Y.
        internal double NewY { get; }

        // Constructor.
        public YHasChangedEventArgs(double newY) => NewY = newY;
    }
}
