using System;

namespace Variant_1
{
    [Serializable]
    public class ControlWork : ControlElement
    {
        public int Variant;

        public ControlWork() { }

        internal ControlWork(int weight, string name, int variant) : base(weight, name)
        {
            if (variant < Program.MinVariant)
                throw new ArgumentOutOfRangeException();

            Variant = variant;
        }

        /// <summary>
        /// Return info about control work.
        /// </summary>
        /// <returns> Info about control work </returns>
        public override string ToString() =>
            $"ControlWork {Variant}" + base.ToString();
    }
}
