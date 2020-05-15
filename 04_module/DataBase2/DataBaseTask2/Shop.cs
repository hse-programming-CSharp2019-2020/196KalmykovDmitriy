using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [Serializable]
    class Shop : IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string TelephoneNumber { get; set; }

        public Shop(long id, string name, string city, string district, string country, string telephoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            District = district;
            Country = country;
            TelephoneNumber = telephoneNumber;
        }
    }
}
