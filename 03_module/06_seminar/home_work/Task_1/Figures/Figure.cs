namespace Figures
{
    public abstract class Figure : IArea
    {
        /// <summary>
        /// Get area of figure.
        /// </summary>
        /// <returns> Area of figure </returns>
        public abstract double GetArea();

        /// <summary>
        /// Return info about figure.
        /// </summary>
        /// <returns> Info about figure </returns>
        public override string ToString() =>
            $"Type: {GetType().Name}\n";
    }
}
