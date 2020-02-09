using DerivedEventArgs;
using System;
using System.Collections.Generic;

namespace Task_4
{
    internal class Chain
    {
        // Events.
        public event EventHandler<ChainLenChangedEventArgs> OnChainLenChangedEvent;
        public event EventHandler<ChainNChangedEventArgs> OnChainNChangedEvent;

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChainNChanged(ChainNChangedEventArgs e) =>
            OnChainNChangedEvent?.Invoke(this, e);

        /// <summary>
        /// Raise event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChainLenChanged(ChainLenChangedEventArgs e) =>
            OnChainLenChangedEvent?.Invoke(this, e);

        // Event.
        internal event ChainRChanged ChainRChangedEvent;

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
                OnChainLenChanged(new ChainLenChangedEventArgs(_len / _n));
            }
        }

        /// <summary>
        /// Change radius.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        public void OnChainLenChangedHandler(object sender,
            ChainLenChangedEventArgs e)
        {
            foreach (var bead in _beads)
                bead.R = e.Rad;
        }

        // Property for amount of beads.
        internal int N
        {
            get => _n;
            set
            {
                _n = value;

                // Raise event.
                OnChainNChanged(new ChainNChangedEventArgs(_n, _len));
            }
        }

        /// <summary>
        /// Change N, because of radius of bead has changed.
        /// </summary>
        /// <param name="r"> New radius </param>
        internal void ChangeR(double r) =>
            _n = (int)(_len / r);

        /// <summary>
        /// Change radius with event call.
        /// </summary>
        /// <param name="r"> Radius </param>
        internal void ChangeRWithEvent(double r)
        {
            foreach (var bead in _beads)
                bead.R = r;

            ChainRChangedEvent?.Invoke(r);
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
