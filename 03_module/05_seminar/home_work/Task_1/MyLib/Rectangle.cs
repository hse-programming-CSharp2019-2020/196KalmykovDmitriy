namespace MyLib
{
    /// <summary>
    /// Class Rectangle.
    /// </summary>
    public class Rectangle
    {
        // Area of rectangle.
        public double Area => Side1 * Side2;

        // Sides of rectangle.
        public double Side1 { get; internal set; }
        public double Side2 { get; internal set; }

        // Constructor.
        public Rectangle(double side1, double side2)
        {
            (Side1, Side2) = (side1, side2);
        }
    }
}
