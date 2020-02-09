using System;

namespace Inhabitants
{
    /// <summary>
    /// My EventArgs.
    /// </summary>
    public class RingIsFoundEventArgs : EventArgs
    {
        // Constructor.
        public RingIsFoundEventArgs(string message) => Message = message;

        // Property.
        public string Message { get; set; }
    }
}
