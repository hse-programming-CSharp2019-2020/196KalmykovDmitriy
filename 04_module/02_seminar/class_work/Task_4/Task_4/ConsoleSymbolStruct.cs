using System;

namespace Task_4
{
    [Serializable]
    internal struct ConsoleSymbolStruct
    {
        public char Symbol { get; }

        // Coordinates.
        public int X { get; }
        public int Y { get; }

        public ConsoleSymbolStruct(char symbol, int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
}
