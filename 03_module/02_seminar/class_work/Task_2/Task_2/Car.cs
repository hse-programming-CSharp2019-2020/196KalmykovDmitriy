using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public delegate void CarEngineHandler(string msgForCaller);

    class Car
    {
        private CarEngineHandler listOfHandlers;
        internal int CurrentSpeed { get; set; }
        internal int MaxSpeed { get; set; }
        internal string PetName { get; set; }

        private bool carIsDead;

        public Car() =>
            MaxSpeed = 100;

        public Car(string name, int maxSp, int currSp) =>
            (PetName, MaxSpeed, CurrentSpeed) = (name, maxSp, currSp);

        public void RegisterWithCarEngine(CarEngineHandler methodToCall) =>
            listOfHandlers = methodToCall;

        public void Accelerate(int delta)
        {
            if (carIsDead)
                listOfHandlers?.Invoke("К сожалению, машина сломана :( ...");
            else
            {
                CurrentSpeed += delta;

                if (10 == MaxSpeed - CurrentSpeed)
                    listOfHandlers?.Invoke("Предупреждение! Будь осторожнее");

                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine($"Скорость = {CurrentSpeed}");
            }
        }
    }
}