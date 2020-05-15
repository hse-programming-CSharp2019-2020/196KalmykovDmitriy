using System;

namespace DataBaseTask2
{
    [Serializable]
    internal class SaleFactory : IEntityFactory<Sale>
    {
        private static long _id;

        private long _amount;
        private double _cost;
        private long _shopId;
        private long _buyerId;
        private long _goodId;

        public SaleFactory(long amount, double cost, long shopId, long buyerId, long goodId)
        {
            _amount = amount;
            _cost = cost;
            _shopId = shopId;
            _buyerId = buyerId;
            _goodId = goodId;
        }

        public Sale Instance => new Sale(_shopId, _buyerId, _goodId,
            _id++, _amount, _cost);
    }
}
