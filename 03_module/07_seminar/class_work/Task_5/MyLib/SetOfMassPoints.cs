using System.Collections.Generic;

namespace MyLib
{
    public struct SetOfMassPoints
    {
        public List<MassPoint> SpecialSetMassPoints;

        // Constructor.
        public SetOfMassPoints(List<MassPoint> massPoints, PointS point, double radius)
        {
            SpecialSetMassPoints = massPoints.FindAll(
                el => el.Coordinates.GetDistance(point) <= radius);
        }

        public MassPoint MassCenter
        {
            get
            {
                double xc = 0, yc = 0, mc = 0;

                foreach (var mp in SpecialSetMassPoints)
                {
                    mc += mp.Mass;
                    xc += mp.Mass * mp.Coordinates.X;
                    yc += mp.Mass * mp.Coordinates.Y;
                }
                return new MassPoint(new PointS(xc / mc, yc / mc), mc);
            }
        }
    }
}
