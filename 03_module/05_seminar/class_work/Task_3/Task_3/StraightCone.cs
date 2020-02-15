namespace Task_3
{
    /// <summary>
    /// Class cone.
    /// </summary>
    internal class StraightCone
    {
        private readonly Circle _circle;
        private readonly Point _vertex;

        // Constructor.
        internal StraightCone(double x, double y, double z, double rad, Point vertex) =>
            (_circle, _vertex) = (new Circle(x, y, z, rad), vertex);

        /// <summary>
        /// Get area of axial section.
        /// </summary>
        /// <returns> Area of axial section </returns>
        internal double GetAxialSectionalArea() =>
            _vertex.GetDistance(_circle.Center) * _circle.Rad;

        /// <summary>
        /// Print info about cone.
        /// </summary>
        /// <returns> Info about cone </returns>
        public override string ToString() =>
            $"Vertex: {_vertex:0.###}\n" +
            $"{_circle:0.###}" +
            $"Area of Axial Section: {GetAxialSectionalArea():0.###}\n";
    }
}
