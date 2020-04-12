using System;

namespace Task_5
{
    [Serializable]
    internal class MyColor
    {
        internal string ColorName;
        internal byte R, G, B;
        internal byte Alpha;

        internal MyColor(string color, byte r, byte g, byte b, byte alpha)
        {
            var temp = color.Substring(3);
            temp = temp.Substring(0, temp.Length - 1);
            var str = char.ToUpper(temp[0]) + temp.Substring(1);

            ColorName = str;
            Alpha = alpha;
            R = r;
            G = g;
            B = b;
        }

        public override string ToString() =>
            $"Color = {ColorName}, R= {R}, G = {G}, B = {B}, Alpha = {Alpha}";
    }
}
