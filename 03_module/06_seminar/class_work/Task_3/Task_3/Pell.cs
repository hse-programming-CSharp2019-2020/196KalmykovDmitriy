using System;

namespace Task_3
{
    internal class Pell : ISeries
    {
        private int _old, _last;

        // Constructor.
        internal Pell() => SetBegin();

        // Set initial data.
        public void SetBegin() =>
            (_old, _last) = (1, 0);

        // Calculate next member of sequence.
        public int GetNext
        {
            get
            {
                var now = _old + 2 * _last;
                _old = _last;
                _last = now;
                return now;
            }
        }

        // Return K-th member of sequence.
        public int this[int k]
        {
            get
            {
                var now = 0;
                SetBegin();

                if (k <= 0) throw new ArgumentOutOfRangeException("Index must be > 0");

                for (var i = 0; i < k; i++)
                    now = GetNext;

                return now;
            }
        }
    }
}
