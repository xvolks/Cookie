using Cookie.API.Game.Entity;

namespace Cookie.Game.Entity
{
    public class Merchant : IMerchant
    {
        public Merchant(int cellId, double id, byte sellType, string name)
        {
            CellId = cellId;
            Id = id;
            SellType = sellType;
            Name = name;
        }

        public int CellId { get; set; }
        public double Id { get; set; }
        public byte SellType { get; }
        public string Name { get; }
    }
}