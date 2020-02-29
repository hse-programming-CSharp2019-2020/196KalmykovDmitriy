namespace MyLib
{
    public struct MassPoint
    {
        // Coordinates.
        public PointS Coordinates;

        // Constructor.
        public MassPoint(PointS coordinates, double mass) =>
            (Coordinates, Mass) = (coordinates, mass);

        // Mass of point.
        public double Mass { get; }

        /// <summary>
        /// Return info about mass point.
        /// </summary>
        /// <returns> Info about mass point </returns>
        public override string ToString() =>
            $"X = {Coordinates.X:0.####}\n" +
            $"Y = {Coordinates.Y:0.####}\n" +
            $"Mass = {Mass:0.####}\n\n";
    }
}
