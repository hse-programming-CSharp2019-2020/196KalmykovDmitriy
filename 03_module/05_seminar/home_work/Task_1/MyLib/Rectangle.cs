using System;

namespace MyLib
{
    /// <summary>
    /// Class Rectangle.
    /// </summary>
    public class Rectangle
    {
        // Event.
        public event EventHandler<SideHasChangedEventArgs> SideHasChangedEvent;

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"> E </param>
        protected virtual void OnSideChanged(SideHasChangedEventArgs e) =>
            SideHasChangedEvent?.Invoke(this, e);

        // Sides of rectangle.
        private double _side1;
        private double _side2;

        // Area of rectangle.
        public double Area => Side1 * Side2;

        // Side 1.
        public double Side1
        {
            get => _side1;
            set
            {
                OnSideChanged(new SideHasChangedEventArgs(value * Side2 / Area, Area));
                _side1 = value;
            }
        }

        // Side 2.
        public double Side2
        {
            get => _side2;
            set
            {
                OnSideChanged(new SideHasChangedEventArgs(value * Side1 / Area, Area));
                _side2 = value;
            }
        }

        // Constructor.
        public Rectangle(double side1, double side2) =>
            (_side1, _side2) = (side1, side2);
    }
}
