using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    [Serializable]
    class Sale:IEntity
    {
        public long ShopId { get; set; }
        public long BuyerId { get; set; }
        public long GoodId { get; set; }

        public long Id { get; }

        public long Amount { get; set; }
        public double Cost { get; set; }

        public Sale(long shopId, long buyerId, long goodId, long id, long amount, double cost)
        {
            ShopId = shopId;
            BuyerId = buyerId;
            GoodId = goodId;
            Id = id;
            Amount = amount;
            Cost = cost;
        }
    }
}
