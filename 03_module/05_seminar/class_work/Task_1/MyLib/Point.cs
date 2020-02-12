using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
     class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y) =>
            (X, Y) = (x, y);

        public double Distance(Point p) =>
            Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
    }
}
