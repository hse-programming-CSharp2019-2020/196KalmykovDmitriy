namespace Task_3
{
    internal interface ISeries
    {
        // Set initial state.
        void SetBegin();

        // Return another member of series.
        int GetNext { get; }

        // Return K-th member of series. 
        int this[int k] { get; }
    }
}
