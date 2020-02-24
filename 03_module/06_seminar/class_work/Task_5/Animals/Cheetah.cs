namespace Animals
{
    public class Cheetah : Animal, IRun, IJump
    {
        // Characteristics of cheetah.
        private readonly int _speed;
        private readonly int _length;

        // Constructor.
        public Cheetah(int age, int speed, int length) : base(age) =>
            (_speed, _length) = (speed, length);

        /// <summary>
        /// Return info about cheetah's running. 
        /// </summary>
        /// <returns> Info about cheetah's running </returns>
        public string Run() =>
            $"The cheetah runs at a speed of {_speed} km / h\n\n";

        /// <summary>
        /// Return info about cheetah's jumping.
        /// </summary>
        /// <returns> Info about cheetah's jumping </returns>
        public string Jump() =>
            $"Cheetah jumps on {_length} m\n";
    }
}