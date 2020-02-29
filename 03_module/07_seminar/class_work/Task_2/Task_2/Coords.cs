namespace Task_2
{
    internal struct Coords
    {
        // Coordinates.
        internal double X { get; set; }
        internal double Y { get; set; }

        // Constructor.
        internal Coords(double x, double y) =>
            (X, Y) = (x, y);

        public override string ToString() =>
            $"X: {X:0.####}, Y: {Y:0.####}";
    }
}
