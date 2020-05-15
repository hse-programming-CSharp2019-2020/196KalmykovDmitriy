using System;

namespace DataBaseTask2
{
    [Serializable]
    internal class BuyerFactory : IEntityFactory<Buyer>
    {
        private static long _id;

        private string _name;
        private string _surname;
        private string _address;
        private string _city;
        private string _district;
        private string _country;
        private string _postcode;

        public BuyerFactory(string name, string surname, string address,
            string city, string district,
            string country, string postcode)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _city = city;
            _district = district;
            _country = country;
            _postcode = postcode;
        }

        public Buyer Instance => new Buyer(_id++, _name, _surname, _address,
             _city, _district, _country, _postcode);
    }
}
