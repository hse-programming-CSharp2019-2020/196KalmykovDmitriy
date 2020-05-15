using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [Serializable]
    class Good : IEntity
    {
        public long Id { get; }
        public long ShopId { get; }
        public string Description { get; }

        public string Name { get; }
        
        public Good(long id, string name, long shopId, string description)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
            Description = description;
        }
    }
}
