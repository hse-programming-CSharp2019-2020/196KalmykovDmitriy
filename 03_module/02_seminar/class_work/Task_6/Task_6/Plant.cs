using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Plant
    {
        private readonly int growth;
        private readonly int photosensitivity;
        private readonly int frostresistance;

        public int Growth { get => growth; }
        public int Photosensitivity { get => photosensitivity; }
        public int Frostresistance { get => frostresistance; set { } }

        public Plant(int growth, int photosensitivity, int frostresistance)
        {
            this.growth = growth;
            this.photosensitivity = photosensitivity;
            this.frostresistance = frostresistance;
        }

        public override string ToString() =>
            $"Рост: {Growth:0.####}, " +
            $"светочувствительность: {Photosensitivity:0.####}, " +
            $"морозоустойчивость: {Frostresistance:0.####}";
    }
}
