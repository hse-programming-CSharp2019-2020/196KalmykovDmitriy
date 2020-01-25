using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        public static void OnCarEngineEvent(string message)
        {
            Console.WriteLine("\n***** Сообщение от объекта типа Car *****");
            Console.WriteLine("=> {0}", message);
            Console.WriteLine("******************************\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Использование делегатов для управления событиями *****\n");
            
            Car c1 = new Car("SlugBug", 100, 10);

            c1.RegisterWithCarEngine(OnCarEngineEvent);

            Console.WriteLine("***** Увеличиваем скорость *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }
    }
}
