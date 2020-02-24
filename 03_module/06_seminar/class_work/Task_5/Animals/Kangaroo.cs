namespace Animals
{
    public class Kangaroo : Animal, IJump
    {
        // Length of jump.
        private readonly int _length;

        // Constructor.
        public Kangaroo(int age, int length) : base(age) =>
            _length = length;

        /// <summary>
        /// Return info about kangaroo's jumping.
        /// </summary>
        /// <returns> Info about kangaroo's jumping </returns>
        public string Jump() =>
            $"Kangaroo jumps on {_length} m\n\n";
    }
}
