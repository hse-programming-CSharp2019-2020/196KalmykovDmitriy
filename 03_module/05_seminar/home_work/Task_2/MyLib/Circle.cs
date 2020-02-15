using System;

namespace MyLib
{
    public class Circle
    {
        // Events.
        public event EventHandler XHasChangedEvent;
        public event EventHandler YHasChangedEvent;

        // Center of circle.
        private readonly Dot _center;

        // Radius.
        private readonly double _radius;

        // Constructor.
        public Circle(Dot dot, double rad) =>
            (_center, _radius) = (dot, rad);

        /// <summary>
        /// Get max X coordinate of circle.
        /// </summary>
        /// <returns> Max X coordinate of circle </returns>
        public double GetMaxX() => _center.GetX() + _radius;

        /// <summary>
        /// Get min X coordinate of circle.
        /// </summary>
        /// <returns> Min X coordinate of circle </returns>
        public double GetMinX() => _center.GetX() - _radius;

        /// <summary>
        /// Change X coordinate.
        /// </summary>
        /// <param name="x"> New X </param>
        public void ChangeXcoord(double x)
        {
            _center.ChangeX(x);

            // Raise event.
            XHasChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
