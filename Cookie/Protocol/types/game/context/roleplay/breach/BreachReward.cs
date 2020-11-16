using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class BreachReward : NetworkType
    {
        public const short ProtocolId = 559;
        public override short TypeId { get { return ProtocolId; } }

        public int Id_ = 0;
        public List<byte> BuyLocks;
        public string BuyCriterion;
        public bool Bought = false;
        public int Price = 0;

        public BreachReward()
        {
        }

        public BreachReward(
            int id_,
            List<byte> buyLocks,
            string buyCriterion,
            bool bought,
            int price
        )
        {
            Id_ = id_;
            BuyLocks = buyLocks;
            BuyCriterion = buyCriterion;
            Bought = bought;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Id_);
            writer.WriteShort((short)BuyLocks.Count());
            foreach (var current in BuyLocks)
            {
                writer.WriteByte(current);
            }
            writer.WriteUTF(BuyCriterion);
            writer.WriteBoolean(Bought);
            writer.WriteVarInt(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarInt();
            var countBuyLocks = reader.ReadShort();
            BuyLocks = new List<byte>();
            for (short i = 0; i < countBuyLocks; i++)
            {
                BuyLocks.Add(reader.ReadByte());
            }
            BuyCriterion = reader.ReadUTF();
            Bought = reader.ReadBoolean();
            Price = reader.ReadVarInt();
        }
    }
}