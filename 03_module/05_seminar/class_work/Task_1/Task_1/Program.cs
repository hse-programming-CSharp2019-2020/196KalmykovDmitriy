using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Task_1
{
    internal class Program
    {
        private static T GetNumber<T>(string message)
        {
            Console.Write(message);

            while (true)
            {
                try
                {
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    return result;
                }
                catch
                {
                    Console.WriteLine(message);
                }
            }
        }

        // Рассмотреть git merge
        // git cherry-pick
        // rebase
        private static void Main()
        {
            var rad = GetNumber<double>(message: "Enter radius ");

            var list = new List<Circle> { new Circle(1, 2, 3), new Circle(3, 2, 1) };

            list.Sort((x, y) => x.Rad.CompareTo(y.Rad));

        }
    }
}
