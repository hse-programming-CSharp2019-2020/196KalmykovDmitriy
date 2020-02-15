using System;

namespace MyLib
{
    /// <summary>
    /// Class Dot.
    /// </summary>
    public class Dot
    {
        // Events.
        public event EventHandler<XHasChangedEventArgs> XHasChangedEvent;
        public event EventHandler<YHasChangedEventArgs> YHasChangedEvent;

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"> E </param>
        protected virtual void OnXHasChanged(XHasChangedEventArgs e) =>
            XHasChangedEvent?.Invoke(this, e);

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"> E </param>
        protected virtual void OnYHasChanged(YHasChangedEventArgs e) =>
            YHasChangedEvent?.Invoke(this, e);

        // Coordinates of dot.
        private double _x;
        private double _y;

        // X coordinate.
        public double X
        {
            get => _x;
            set
            {
                _x = value;

                // Raise event.
                OnXHasChanged(new XHasChangedEventArgs(_x));
            }
        }

        // Y coordinate.
        public double Y
        {
            get => _y;
            set
            {
                _y = value;

                // Raise event.
                OnYHasChanged(new YHasChangedEventArgs(_y));
            }
        }

        // Constructor.
        public Dot(double x, double y) =>
            (X, Y) = (x, y);
    }
}
