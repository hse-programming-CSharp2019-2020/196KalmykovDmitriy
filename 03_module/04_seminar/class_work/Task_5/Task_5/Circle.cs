using System;

namespace Task_5
{
    /// <summary>
    /// Class circle.
    /// </summary>
    internal class Circle
    {
        // Radius.
        private int _r;

        // Event.
        public event RadiusChanged OnRadiusChanged;

        // Property for radius.
        public int R
        {
            get => _r;
            set
            {
                _r = value;

                // Raise event.
                OnRadiusChanged?.Invoke();
            }
        }

        // Constructor.
        public Circle(int rad)
        {
            if (rad < 0)
                throw new ArgumentOutOfRangeException("Radius must be > 0");

            _r = rad;
        }
    }
}
