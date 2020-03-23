using System;

namespace MyLIb
{
    public struct ConsoleSymbolStruct
    {
        public char Symbol { get; }
        public int X { get; }
        public int Y { get; }

        public ConsoleSymbolStruct(char symbol, int x, int y)
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
