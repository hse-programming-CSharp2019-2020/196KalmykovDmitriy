namespace Task_3
{
    internal interface IFigure
    {
        // Area of figure.
        double GetArea { get; }

        /// <summary>
        /// Return info about figure.
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
