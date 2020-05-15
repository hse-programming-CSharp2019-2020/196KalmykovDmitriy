using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    internal static class Tasks
    {
        internal static void Task1(DataBase db)
        {
            var maxLength = db
                .Table<Buyer>()
                .Max(b => b.Name.Length);

            var buyerWithMaxLengthName = db
                .Table<Buyer>()
                .FirstOrDefault(b => b.Name.Length == maxLength);

            IEnumerable<long> sales = db
                .Table<Sale>()
                .Where(s => s.BuyerId == buyerWithMaxLengthName.Id)
                .Select(s => s.GoodId)
                .ToList();

            string result = db
                .Table<Good>()
                .Where(g => sales.Contains(g.Id))
                .Select(g => g.Name)
                .FirstOrDefault();

            Console.WriteLine();
            Console.WriteLine($"Goods purchased by the user with the longest name: {result}");
        }

        internal static void Task2(DataBase db)
        {
            var maxCostSaleValue = db
                .Table<Sale>()
                .Max(s => s.Cost);

            var maxCostGoodId = db
                .Table<Sale>()
                .Where(s => s.Cost == maxCostSaleValue)
                .Select(s => s.GoodId)
                .FirstOrDefault();

            var categoryMostExpensiveGood = db
                .Table<Good>()
                .Where(g => g.Id == maxCostGoodId)
                .Select(g => g.Description)
                .FirstOrDefault();

            Console.WriteLine();
            Console.WriteLine($"Category of the most expensive products: {categoryMostExpensiveGood}");
        }

        internal static void Task3(DataBase db)
        {
            // Найти город, в которм сумма продаж наименьшая

            IEnumerable<IGrouping<string, Buyer>> buyersByCity = db
                .Table<Buyer>()
                .GroupBy(b => b.City);

            var min = double.MaxValue;
            var minCity = string.Empty;

            foreach (IGrouping<string, Buyer> buyers in buyersByCity)
            {
                IEnumerable<long> buyersInCity = db
                    .Table<Buyer>()
                    .Where(s => s.City == buyers.Key)
                    .Select(b => b.Id);

                var query = db
                    .Table<Sale>()
                    .Where(s => buyersInCity.Contains(s.Id))
                    .Sum(s => s.Cost);

                if (!(query < min))
                {
                    continue;
                }

                min = query;
                minCity = buyers.Key;
            }

            Console.WriteLine();
            Console.WriteLine($"City: {minCity}");
        }

        internal static void Task4(DataBase db)
        {
            var good = db
                .Table<Sale>()
                .OrderByDescending(s => s.Cost)
                .FirstOrDefault();

            List<long> buyersId = db
                .Table<Sale>()
                .Where(s => s.Id == good.Id)
                .Select(s => s.BuyerId)
                .ToList();

            IEnumerable<string> query = db
                .Table<Buyer>()
                .Where(b => buyersId.Contains(b.Id))
                .Select(b => b.Surname)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Surnames: ");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
