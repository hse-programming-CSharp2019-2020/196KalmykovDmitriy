using System.Collections.Generic;

namespace MyLib
{
    public class ColorPoint
    {
        // Colors.
        public static Dictionary<int, string> Colors = new Dictionary<int, string>
        {
            [0] = "Red",
            [1] = "Green",
            [2] = "DarkRed",
            [3] = "Magenta",
            [4] = "DarkSeaGreen",
            [5] = "Lime",
            [6] = "Purple",
            [7] = "DarkGreen",
            [8] = "DarkOrange",
            [9] = "Black",
            [10] = "BlueViolet",
            [11] = "Crimson",
            [12] = "Gray",
            [13] = "Brown",
            [14] = "CadetBlue"
        };

        public double X, Y;
        public string Color;

        /// <summary>
        /// Return info about point.
        /// </summary>
        /// <returns> Info about point </returns>
        public override string ToString()
        {
            return $"{X:f3} {Y:f3} {Color}";
        }
    }
}
