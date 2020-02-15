using System;

namespace MyLib
{
    /// <summary>
    /// My EventArgs.
    /// </summary>
    public class SideHasChangedEventArgs : EventArgs
    {
        // Coefficient of area's ratio.
        internal double Coefficient { get; }

        // Old area.
        internal double OldArea { get; }

        // Constructor.
        internal SideHasChangedEventArgs(double coefficient, double area) =>
            (Coefficient, OldArea) = (coefficient, area);
    }
}
