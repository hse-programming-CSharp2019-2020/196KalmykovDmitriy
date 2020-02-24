using System;

namespace Task_3
{
    internal class Luke : ISeries
    {
        private int _old, _last;

        // Constructor.
        internal Luke() => SetBegin();

        // Set initial data.
        public void SetBegin() =>
            (_old, _last) = (0, 2);

        // Calculate next member of sequence.
        public int GetNext
        {
            get
            {
                // Check first and second member separately.
                switch (_old)
                {
                    case 0 when _last == 2:
                        _old = 2;
                        _last = 2;
                        return 2;

                    case 2 when _last == 2:
                        _old = 2;
                        _last = 1;
                        return 1;
                }

                var now = _old + _last;
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
