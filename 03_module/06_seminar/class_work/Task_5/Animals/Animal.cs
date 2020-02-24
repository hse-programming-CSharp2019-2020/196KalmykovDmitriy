namespace Animals
{
    public abstract class Animal
    {
        // Constructor.
        protected Animal(int age) =>
            Age = age;

        // Age of animal.
        public int Age { get; set; }

        /// <summary>
        /// Return info about animal.
        /// </summary>
        /// <returns> Info about animal </returns>
        public string Descript() =>
            $"{GetType().Name}. Age: {Age}";
    }
}
