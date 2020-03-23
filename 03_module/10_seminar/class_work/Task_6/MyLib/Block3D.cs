using System;

namespace MyLib
{
    public class Block3D : IComparable
    {
        private double _height;
        public Rectangle Base { get; set; } 
        internal double Volume => Base.Area * _height;

        // Property for height.
        public double Height
        {
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _height = value;
            }
        }

        // Constructor.
        public Block3D(double h, double baseH, double baseW)
        {
            Base = new Rectangle(baseH, baseW);
            Height = h;
        }

        /// <summary>
        /// Implementation IComparable.
        /// </summary>
        /// <param name="another"> Other block </param>
        /// <returns> -1, 1, or 0 </returns>
        public int CompareTo(object another)
        {
            if (!(another is Block3D))
            {
                throw new TypeLoadException();
            }

            var anotherBlock = (Block3D)another;

            return Volume.CompareTo(anotherBlock.Volume);
        }

        /// <summary>
        /// Return info about block.
        /// </summary>
        /// <returns> Info about block </returns>
        public override string ToString()
        {
            return $"Block height:: {_height:f3} Base::{Base}";
        }
    }
}
