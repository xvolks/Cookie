using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BreachReward : NetworkType
    {
        public const ushort ProtocolId = 559;

        public override ushort TypeID => ProtocolId;

        public uint Id { get; set; }
        public List<sbyte> BuyLocks { get; set; }
        public string BuyCriterion { get; set; }
        public bool Bought { get; set; }
        public uint Price { get; set; }
        public BreachReward() { }

        public BreachReward( uint Id, List<sbyte> BuyLocks, string BuyCriterion, bool Bought, uint Price ){
            this.Id = Id;
            this.BuyLocks = BuyLocks;
            this.BuyCriterion = BuyCriterion;
            this.Bought = Bought;
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Id);
			writer.WriteShort((short)BuyLocks.Count);
			foreach (var x in BuyLocks)
			{
				writer.WriteSByte(x);
			}
            writer.WriteUTF(BuyCriterion);
            writer.WriteBoolean(Bought);
            writer.WriteVarUhInt(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhInt();
            var BuyLocksCount = reader.ReadShort();
            BuyLocks = new List<sbyte>();
            for (var i = 0; i < BuyLocksCount; i++)
            {
                BuyLocks.Add(reader.ReadSByte());
            }
            BuyCriterion = reader.ReadUTF();
            Bought = reader.ReadBoolean();
            Price = reader.ReadVarUhInt();
        }
    }
}
