namespace MyLib
{
    public struct MassPoint
    {
        // Center.
        public PointS Center;

        public double Mass { get; }

        // Constructor.
        public MassPoint(PointS point, double mass)
        {
            Center = point;
            Mass = mass;
        }

        /// <summary>
        /// Return info about mass point.
        /// </summary>
        /// <returns> Info about mass point </returns>
        public override string ToString()
        {
            var result = $"x={Center.X},\ty={Center.Y},\tmass={Mass}";

            return result;
        }
    }
}
