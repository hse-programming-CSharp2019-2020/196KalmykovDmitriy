using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine($"Task 1: {result}");
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
            Console.WriteLine($"Task2: {categoryMostExpensiveGood}");
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
            Console.WriteLine($"Task 3: {minCity}");
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
            Console.WriteLine("Task 4: ");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        internal static void Task5(DataBase db)
        {
            // Найти кол-во магазинов в странеЮ где их меньше всего.
            var shopsByCountry = db
                .Table<Shop>()
                .GroupBy(s => s.Country);

            var min = shopsByCountry
                .Select(shops => shops.Count())
                .Concat(new[] { int.MaxValue })
                .Min();

            Console.WriteLine();
            Console.WriteLine($"Task 5: {min}");
        }

        internal static void Task6(DataBase db)
        {
            Console.WriteLine();
            Console.WriteLine("Task 6:");
            // Найти покупки, которые были сделаны не в своём городе
            foreach (var buyer in db.Table<Buyer>())
            {
                Console.WriteLine();
                foreach (var shop in db.Table<Shop>())
                {
                    Console.WriteLine($"{shop.City}: ");
                    if (buyer.City != shop.City)
                    {
                        IEnumerable<long> query = db
                            .Table<Sale>()
                            .Where(s => s.ShopId == shop.Id)
                            .Select(s => s.GoodId);

                        foreach (var item in query)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }
        }

        internal static void Task7(DataBase db)
        {
            // стоимость всех покупок
            Console.WriteLine();
            var res = db
                .Table<Sale>()
                .Sum(s => s.Cost);

            Console.WriteLine($"Task 7: {res}");
        }
    }
}
