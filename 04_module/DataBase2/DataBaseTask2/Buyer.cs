using System;

namespace DataBaseTask2
{
    [Serializable]
    class Buyer : IEntity
    {
        public long Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }

        public Buyer(long id, string name, string surname,
            string address, string city, string district,
            string country, string postcode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            District = district;
            Country = country;
            Postcode = postcode;
        }
    }
}
