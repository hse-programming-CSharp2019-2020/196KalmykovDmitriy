using System;

namespace Task_4
{
    internal class ConsoleSymbolClass
    {
        public char Symbol { get; }

        // Coordinates.
        public int X { get; }
        public int Y { get; }

        public ConsoleSymbolClass(char symbol, int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
}
