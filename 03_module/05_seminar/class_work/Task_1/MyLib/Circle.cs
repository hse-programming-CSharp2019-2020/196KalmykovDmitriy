namespace MyLib
{
    public class Circle
    {
        // Radius.
        public double Rad { get; set; }

        // Center of circle.
        private readonly Point _center;

        // Constructor
        public Circle(double rad, double x, double y) =>
            (_center, Rad) = (new Point(x, y), rad);

        /// <summary>
        /// My ToString().
        /// </summary>
        /// <returns> Info about circle </returns>
        public override string ToString() =>
            $"Radius: {Rad}\n" +
            $"(x, y): ({_center.X}, {_center.Y})\n";

        /// <summary>
        /// Override operator >.
        /// </summary>
        /// <param name="cir1"> Circle 1 </param>
        /// <param name="cir2"> Circle 2 </param>
        /// <returns> True or false </returns>
        public static bool operator >(Circle cir1, Circle cir2) =>
            cir1._center.Distance(new Point(0, 0)) * cir1.Rad >
            cir2._center.Distance(new Point(0, 0)) * cir2.Rad;

        /// <summary>
        /// Override operator <.
        /// </summary>
        /// <param name="cir1"> Circle 1 </param>
        /// <param name="cir2"> Circle 2 </param>
        /// <returns> True or false </returns>
        public static bool operator <(Circle cir1, Circle cir2) =>
            cir1._center.Distance(new Point(0, 0)) * cir1.Rad >
            cir2._center.Distance(new Point(0, 0)) * cir2.Rad;
    }
}
