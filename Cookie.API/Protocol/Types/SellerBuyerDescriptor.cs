using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SellerBuyerDescriptor : NetworkType
    {
        public const ushort ProtocolId = 121;

        public override ushort TypeID => ProtocolId;

        public List<int> Quantities { get; set; }
        public List<int> Types { get; set; }
        public float TaxPercentage { get; set; }
        public float TaxModificationPercentage { get; set; }
        public byte MaxItemLevel { get; set; }
        public uint MaxItemPerAccount { get; set; }
        public int NpcContextualId { get; set; }
        public ushort UnsoldDelay { get; set; }
        public SellerBuyerDescriptor() { }

        public SellerBuyerDescriptor( List<int> Quantities, List<int> Types, float TaxPercentage, float TaxModificationPercentage, byte MaxItemLevel, uint MaxItemPerAccount, int NpcContextualId, ushort UnsoldDelay ){
            this.Quantities = Quantities;
            this.Types = Types;
            this.TaxPercentage = TaxPercentage;
            this.TaxModificationPercentage = TaxModificationPercentage;
            this.MaxItemLevel = MaxItemLevel;
            this.MaxItemPerAccount = MaxItemPerAccount;
            this.NpcContextualId = NpcContextualId;
            this.UnsoldDelay = UnsoldDelay;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Quantities.Count);
			foreach (var x in Quantities)
			{
				writer.WriteVarInt(x);
			}
			writer.WriteShort((short)Types.Count);
			foreach (var x in Types)
			{
				writer.WriteVarInt(x);
			}
            writer.WriteFloat(TaxPercentage);
            writer.WriteFloat(TaxModificationPercentage);
            writer.WriteByte(MaxItemLevel);
            writer.WriteVarUhInt(MaxItemPerAccount);
            writer.WriteInt(NpcContextualId);
            writer.WriteVarUhShort(UnsoldDelay);
        }

        public override void Deserialize(IDataReader reader)
        {
            var QuantitiesCount = reader.ReadShort();
            Quantities = new List<int>();
            for (var i = 0; i < QuantitiesCount; i++)
            {
                Quantities.Add(reader.ReadVarInt());
            }
            var TypesCount = reader.ReadShort();
            Types = new List<int>();
            for (var i = 0; i < TypesCount; i++)
            {
                Types.Add(reader.ReadVarInt());
            }
            TaxPercentage = reader.ReadFloat();
            TaxModificationPercentage = reader.ReadFloat();
            MaxItemLevel = reader.ReadByte();
            MaxItemPerAccount = reader.ReadVarUhInt();
            NpcContextualId = reader.ReadInt();
            UnsoldDelay = reader.ReadVarUhShort();
        }
    }
}
