using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security;

namespace DataBaseTask2
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        #region Paths to files.

        private const string PathDbShop = "DBShop.json";
        private const string PathDbGood = "DBGood.json";
        private const string PathDbBuyer = "DBBuyer.json";
        private const string PathDbSale = "DBSale.json";

        #endregion

        static void Main()
        {
            do
            {
                var db = new DataBase("ShopDataBase");

                CreateTables(ref db);

                InsertObjects(ref db);

                IEnumerable<Buyer> buyers = db.Table<Buyer>();
                IEnumerable<Good> goods = db.Table<Good>();

                for (var i = 0; i < 5; i++)
                {
                    var curBuyer = buyers
                        .Skip(Math.Max(Rnd.Next(3) - i, 0))
                        .FirstOrDefault();

                    var curGood = goods
                        .Skip(Math.Max(Rnd.Next(3) - i, 0))
                        .FirstOrDefault();

                    db.InsertInto(new SaleFactory(Rnd.Next(15),
                        GetDoubleFromInterval(), curGood.ShopId, curBuyer.Id, curGood.Id));
                }

                var auchanId = (from shop in db.Table<Shop>()
                                where shop.Name == "Auchan"
                                select shop.Id).First();

                IEnumerable<string> allAuchanGoods = from good in db.Table<Good>()
                                                     where good.ShopId == auchanId
                                                     select good.Name;

                foreach (var goodName in allAuchanGoods)
                {
                    Console.WriteLine(goodName);
                }


                // Try catch.
                SerializeObjects(db);
                var dbNew = GetNewDataBase();
                Console.Clear();
                Tasks.Task1(db);
                Tasks.Task2(db);
                Tasks.Task3(db);
                Tasks.Task4(db);
                Console.WriteLine("Press esc to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            //Console.WriteLine("Serialization was successful");

            Console.WriteLine();

        }
        // категория самого дорого товара






        private static void InsertObjects(ref DataBase db)
        {
            InsertShops(ref db);

            InsertGoods(ref db);

            InsertBuyers(ref db);
        }

        private static double GetDoubleFromInterval() =>
           Rnd.NextDouble() + Rnd.Next(100);

        private static void SerializeObjects(DataBase db)
        {
            Serialize(PathDbShop, db.Table<Shop>());
            Serialize(PathDbGood, db.Table<Good>());
            Serialize(PathDbBuyer, db.Table<Buyer>());
            Serialize(PathDbSale, db.Table<Sale>());
        }

        private static void CreateTables(ref DataBase db)
        {
            db.CreateTable<Shop>();
            db.CreateTable<Good>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();
        }

        private static DataBase GetNewDataBase()
        {

            var dbNew = new DataBase("ShopDataBase");

            CreateTables(ref dbNew);

            IEnumerable<Shop> shops = Deserialize<Shop>(PathDbShop);
            IEnumerable<Good> goods = Deserialize<Good>(PathDbGood);
            IEnumerable<Buyer> buyers = Deserialize<Buyer>(PathDbBuyer);
            IEnumerable<Sale> sales = Deserialize<Sale>(PathDbSale);

            foreach (var shop in shops)
            {
                dbNew.InsertInto(new ShopFactory(shop.Name, shop.City, shop.District,
                    shop.Country, shop.TelephoneNumber));
            }

            foreach (var good in goods)
            {
                dbNew.InsertInto(new GoodFactory(good.Name, good.ShopId, good.Description));
            }

            foreach (var buyer in buyers)
            {
                dbNew.InsertInto(new BuyerFactory(buyer.Name, buyer.Surname, buyer.Address,
                    buyer.City, buyer.District, buyer.Country, buyer.Postcode));
            }

            foreach (var sale in sales)
            {
                dbNew.InsertInto(new SaleFactory(sale.Amount, sale.Cost, sale.ShopId,
                    sale.BuyerId, sale.GoodId));
            }

            return dbNew;
        }

        private static void Serialize<T>(string path, T args)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    var formatter = new DataContractJsonSerializer(typeof(T));

                    formatter.WriteObject(fs, args);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Some problem with file");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Access error");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error");
            }
        }

        private static IEnumerable<T> Deserialize<T>(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var formatter = new DataContractJsonSerializer(typeof(IEnumerable<T>));

                    var shops = (IEnumerable<T>)formatter.ReadObject(fs);

                    return shops;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Some problem with file");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Access error");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error");
            }

            return Enumerable.Empty<T>();
        }

        private static void InsertShops(ref DataBase db)
        {
            db.InsertInto(new ShopFactory("Auchan", "Moscow",
                "District 1", "Russia", "29538159382"));

            db.InsertInto(new ShopFactory("Magnit", "Moscow",
                "District 2", "Russia", "47291284739"));

            db.InsertInto(new ShopFactory("Diksi", "Moscow",
                "District 3", "Russia", "32135829481"));
        }

        private static void InsertGoods(ref DataBase db)
        {
            db.InsertInto(new GoodFactory("Pepsi", 1, "Category 1"));
            db.InsertInto(new GoodFactory("3 korochki", 1, "Category 2"));
            db.InsertInto(new GoodFactory("Ohota", 2, "Category 2"));
            db.InsertInto(new GoodFactory("Lays", 3, "Category 1"));
        }

        private static void InsertBuyers(ref DataBase db)
        {
            db.InsertInto(new BuyerFactory("Dima_1", "Kalmykov_1", "Home_1",
                "Moscow", "District 1", "Russia", "395820"));

            db.InsertInto(new BuyerFactory("Dima_2", "Kalmykov_2", "Home_2",
                "Moscow", "District 2", "Russia", "492583"));

            db.InsertInto(new BuyerFactory("Dima_3", "Kalmykov_3", "Home_3",
                "Moscow", "District 3", "Russia", "859205"));
        }
    }
}