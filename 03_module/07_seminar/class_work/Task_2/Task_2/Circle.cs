using System;

namespace Task_2
{
    internal class Circle
    {
        // Radius of circle.
        private double _radius;

        // Center of circle.
        internal Coords Center { get; set; }

        internal double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be positive!");
                }

                _radius = value;
            }
        }

        internal Circle(double x, double y, double radius) =>
            (Center, Radius) = (new Coords(x, y), radius);

        internal Circle(Coords center, double radius) =>
            (Center, Radius) = (center, radius);

        public override string ToString() =>
            $"Center: {Center}\n" +
            $"Radius: {Radius:0.####}\n\n";
    }
}
