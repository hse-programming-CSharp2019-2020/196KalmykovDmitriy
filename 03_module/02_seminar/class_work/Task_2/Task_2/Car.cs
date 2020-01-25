using System;

namespace Task_2
{
    // Declare delegate.
    public delegate void CarEngineHandler(string msgForCaller);

    /// <summary>
    /// Class car.
    /// </summary>
    class Car
    {
        private CarEngineHandler listOfHandlers;

        // Info about car.
        internal int CurrentSpeed { get; private set; }
        internal int MaxSpeed { get; }
        internal string PetName { get; }

        // Car's condition.
        private bool carIsDead;

        // Default constructor.
        public Car() =>
            MaxSpeed = 100;

        // Constructor.
        public Car(string name, int maxSp, int curSp) =>
            (PetName, MaxSpeed, CurrentSpeed) = (name, maxSp, curSp);

        // Set method for notifications.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall) =>
            listOfHandlers = methodToCall;

        /// <summary>
        /// Method for accelerate speed.
        /// </summary>
        /// <param name="delta"> Figure for change speed </param>
        public void Accelerate(int delta)
        {
            if (carIsDead)
                listOfHandlers?.Invoke("К сожалению, машина сломана :( ...");
            else
            {
                // Increase speed.
                CurrentSpeed += delta;

                // First notification.
                if (10 == MaxSpeed - CurrentSpeed)
                    listOfHandlers?.Invoke("Предупреждение! Будь осторожнее");

                // Last notification.
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine($"Скорость = {CurrentSpeed}");
            }
        }
    }
}