namespace MyLib
{
    internal interface IInterRoot
    {
        /// <summary>
        /// Find root.
        /// </summary>
        /// <returns> Root </returns>
        double RootSearch();

        // Amount of iterations.
        int IterationQuantity { get; }
    }
}
