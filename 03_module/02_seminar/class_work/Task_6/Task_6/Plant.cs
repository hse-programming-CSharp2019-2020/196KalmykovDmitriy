using System;

namespace Task_6
{
    /// <summary>
    /// Class plant.
    /// </summary>
    internal class Plant
    {
        // Require feature of plant.
        private readonly int frostresistance;
        private readonly int photosensitivity;
        private readonly int growth;

        // Property.
        public int Growth { get; }
        public int Photosensitivity { get; }
        public int Frostresistance { get; set; }

        // Constructor.
        public Plant(int growth, int photosensitivity, int frostresistance)
        {
            if (growth < 0 ||
                photosensitivity > 100 || photosensitivity < 0 ||
                frostresistance > 100 || frostresistance < 0)
                throw new ArgumentOutOfRangeException(
                    "parameter values are not in the valid range");

            Growth = growth;
            Photosensitivity = photosensitivity;
            Frostresistance = frostresistance;
        }

        /// <summary>
        /// Info about plant.
        /// </summary>
        /// <returns> Info about plant </returns>
        public override string ToString() =>
            $"Growth: {Growth:0.####}, " +
            $"photosensitivity: {Photosensitivity:0.####}, " +
            $"frostresistance: {Frostresistance:0.####}";
    }
}