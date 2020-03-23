using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public struct SetOfMassPoint
    {
        // SEt of points.
        private readonly List<MassPoint> _set;

        // Radius.
        public double Radius { get; }

        // Constructor.
        public SetOfMassPoint(IEnumerable<MassPoint> collection, PointS point, double rad)
        {
            _set = collection.Where(mp => mp.Center.GetDistance(point) <= rad).ToList();
            Radius = rad;
        }

        // Mass center.
        public MassPoint MassCenter
        {
            get
            {
                double xc = 0, yc = 0, mc = 0;

                foreach (MassPoint mp in _set)
                {
                    mc += mp.Mass;
                    xc += mp.Mass * mp.Center.X;
                    yc += mp.Mass * mp.Center.Y;
                }

                return new MassPoint(new PointS(xc / mc, yc / mc), mc);
            }
        }

        /// <summary>
        /// Return info about set.
        /// </summary>
        /// <returns> Info about set </returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var point in _set)
            {
                result.AppendLine(point.ToString());
            }

            return result.ToString();
        }
    }
}
