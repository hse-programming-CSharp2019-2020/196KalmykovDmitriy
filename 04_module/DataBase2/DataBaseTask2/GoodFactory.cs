using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [Serializable]
    class GoodFactory : IEntityFactory<Good>
    {
        public string Description { get; }
        private static long _id;

        private string _name;

        private long _shopId;

        public GoodFactory(string name, long shopId, string description)
        {
            Description = description;
            _name = name;
            _shopId = shopId;
        }

        public Good Instance => new Good(_id++, _name, _shopId, Description);
    }
}
