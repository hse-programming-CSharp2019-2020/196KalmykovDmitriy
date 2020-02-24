namespace Task_2
{
    internal abstract class Animal
    {
        // Name of animal.
        internal string Name { get; }

        // Constructor.
        internal Animal(string name) => Name = name;

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        internal abstract void OnTrainingStartedHandler(object sender, TrainingEventArgs e);
    }
}
