using System;

namespace Task_2
{
    // Declare delegate.
    internal delegate void CarEngineHandler(string msgForCaller);

    /// <summary>
    /// Class car.
    /// </summary>
    internal class Car
    {
        private CarEngineHandler listOfHandlers;

        // Info about car.
        internal int CurrentSpeed { get; private set; }
        private int MaxSpeed { get; }
        private string PetName { get; }

        // Car's condition.
        private bool carIsDead;

        // Default constructor.
        internal Car() =>
            MaxSpeed = 100;

        // Constructor.
        internal Car(string name, int maxSp, int curSp)
        {
            if (name is null || maxSp < 0 || curSp < 0)
                throw new ArgumentOutOfRangeException("Speed must be positive");

            (PetName, MaxSpeed, CurrentSpeed) = (name, maxSp, curSp);
        }

        // Set method for notifications.
        internal void RegisterWithCarEngine(CarEngineHandler methodToCall) =>
            listOfHandlers = methodToCall;

        /// <summary>
        /// Method for accelerate speed.
        /// </summary>
        /// <param name="delta"> Figure for change speed </param>
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentOutOfRangeException("Delta must be positive");

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