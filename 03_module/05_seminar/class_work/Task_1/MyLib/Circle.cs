using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
   public class Circle
    {

        private double rad;
        public double Rad { get; set; }

        private Point center;

        public Circle(double rad, double x, double y) =>
            (center, Rad) = (new Point(x, y), rad);

        public override string ToString() =>
            $"Radius: {Rad}\n" +
            $"(x, y); ({center.X}, {center.Y}\n";
    }
}
