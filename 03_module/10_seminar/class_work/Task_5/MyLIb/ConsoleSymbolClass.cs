using System;

namespace MyLIb
{
    public class ConsoleSymbolClass
    {
        public char Symbol { get; }
        public int X { get; }
        public int Y { get; }

        public ConsoleSymbolClass(char symbol, int x, int y)
        {
            if (x < 0 || y < 0 || x > 25 || y > 25)
            {
                throw new ArgumentOutOfRangeException();
            }

            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
}
