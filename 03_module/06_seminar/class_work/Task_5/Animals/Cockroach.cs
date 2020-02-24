namespace Animals
{
    public class Cockroach : Animal, IRun
    {
        // Speed of run.
        private readonly int _speed;

        // Constructor.
        public Cockroach(int age, int speed) : base(age) =>
            _speed = speed;

        /// <summary>
        /// Return info about cockroach's running.
        /// </summary>
        /// <returns> Info about cockroach's running </returns>
        public string Run() =>
            $"The cockroach runs at a speed of {_speed} km / h\n\n";
    }
}
