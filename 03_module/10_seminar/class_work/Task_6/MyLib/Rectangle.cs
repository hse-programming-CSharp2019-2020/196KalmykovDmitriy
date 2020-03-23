using System;

namespace MyLib
{
    public struct Rectangle : IComparable
    {
        internal double Height;
        internal double Width;
        internal double Area => Height * Width;

        // Constructor.
        public Rectangle(double h, double w)
        {
            if (h < 0 || w < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Height = h;
            Width = w;
        }

        /// <summary>
        /// Implementation IComparable.
        /// </summary>
        /// <param name="another"> another rectangle </param>
        /// <returns> -1, 1, or 0 </returns>
        public int CompareTo(object another)
        {
            if (!(another is Rectangle))
            {
                throw new TypeLoadException();
            }

            var anotherRectangle = (Rectangle)another;

            return Area.CompareTo(anotherRectangle.Area);
        }

        /// <summary>
        /// Return info about rectangle.
        /// </summary>
        /// <returns> Info about rectangle </returns>
        public override string ToString()
        {
            return $"h: {Height:f3}, w: {Width:f3}";
        }
    }
}
