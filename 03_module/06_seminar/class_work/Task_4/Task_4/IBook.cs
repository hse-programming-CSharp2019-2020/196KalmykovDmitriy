namespace Task_4
{
    internal interface IBook : IPublication
    {
        string Author { set; get; }

        // Amount of pages.
        int Pages { set; get; }

        // Publishing house.
        string Publisher { get; }

        // Year of publication.
        int Year { get; set; }
    }
}
