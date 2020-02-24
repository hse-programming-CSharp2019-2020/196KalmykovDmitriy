using System;

namespace Figures
{
    public class Cube : Figure, IVolume
    {
        // Rib of cube.
        private double Rib { get; }

        // Constructor.
        public Cube(double rib)
        {
            if (rib <= 0)
                throw new ArgumentOutOfRangeException("Side of cube must be > 0!");

            Rib = rib;
        }

        /// <summary>
        /// Get surface area.
        /// </summary>
        /// <returns> Surface area </returns>
        public override double GetArea() =>
            6 * Rib * Rib;

        /// <summary>
        /// Get volume of cube.
        /// </summary>
        /// <returns> Volume of cube </returns>
        public double GetVolume() => Math.Pow(Rib, 3);

        /// <summary>
        /// Return info about cube.
        /// </summary>
        /// <returns> Info about cube </returns>
        public override string ToString() =>
            base.ToString() + $"Area of cube's cover: {GetArea():0.####}\n" +
            $"Volume of cube: {GetVolume():0.####}";
    }
}
