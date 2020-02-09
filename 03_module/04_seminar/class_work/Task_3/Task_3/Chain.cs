using System.Collections.Generic;

namespace Task_3
{
    /// <summary>
    /// Class Chain form beads.
    /// </summary>
    internal class Chain
    {

        // Events.
        internal event ChainNChanged ChainNChangedEvent;
        internal event ChainRChanged ChainRChangedEvent;
        internal event ChainLenChanged ChainLenChangedEvent;

        // Some variable.
        private int _n;
        private double _len;
        private readonly List<Bead> _beads = new List<Bead>();

        // Property for length of chain.
        internal double Len
        {
            get => _len;
            set
            {
                _len = value;

                // Raise event.
                ChainLenChangedEvent?.Invoke(_len / _n);
            }
        }


        // Property for amount of beads.
        internal int N
        {
            get => _n;
            set
            {
                _n = value;

                // Raise event.
                ChainNChangedEvent?.Invoke(_n, _len);
            }
        }

        /// <summary>
        /// Change N, because of radius of bead has changed.
        /// </summary>
        /// <param name="r"> New radius </param>
        internal void ChangeR(double r) =>
            _n = (int)(_len / r);

        internal void ChangeRWithEvent(double r)
        {
            foreach (var bead in _beads)
                bead.R = r;

            ChainRChangedEvent?.Invoke(r);
        }


        /// <summary>
        /// Change radius, because of length of chain has changed.
        /// </summary>
        /// <param name="r"> New radius </param>
        internal void ChangeLen(double r)
        {
            foreach (var bead in _beads)
                bead.R = r;
        }

        // Constructor.
        internal Chain(double length, int amount)
        {
            (_len, _n) = (length, amount);

            CreateBeads(_len / _n, _n);
        }

        /// <summary>
        /// Create list from beads.
        /// </summary>
        /// <param name="r"> Radius of bead </param>
        /// <param name="amount"> Amount of beads </param>
        internal void CreateBeads(double r, int amount)
        {
            _beads.Clear();

            for (var i = 0; i < amount; i++)
            {
                var bead = new Bead(r);
                _beads.Add(bead);
            }
        }

        /// <summary>
        /// New ToString()
        /// </summary>
        /// <returns> Info about chain </returns>
        public override string ToString() =>
            $"\nAmount of beads: {_n}\n" +
            $"Length of chain: {_len:0.##}\n" +
            $"Radius of bead: {_len / _n:0.##}\n\n";
    }
}
