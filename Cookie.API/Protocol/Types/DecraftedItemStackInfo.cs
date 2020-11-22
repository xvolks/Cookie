using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DecraftedItemStackInfo : NetworkType
    {
        public const ushort ProtocolId = 481;

        public override ushort TypeID => ProtocolId;

        public uint ObjectUID { get; set; }
        public float BonusMin { get; set; }
        public float BonusMax { get; set; }
        public List<short> RunesId { get; set; }
        public List<int> RunesQty { get; set; }
        public DecraftedItemStackInfo() { }

        public DecraftedItemStackInfo( uint ObjectUID, float BonusMin, float BonusMax, List<short> RunesId, List<int> RunesQty ){
            this.ObjectUID = ObjectUID;
            this.BonusMin = BonusMin;
            this.BonusMax = BonusMax;
            this.RunesId = RunesId;
            this.RunesQty = RunesQty;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteFloat(BonusMin);
            writer.WriteFloat(BonusMax);
			writer.WriteShort((short)RunesId.Count);
			foreach (var x in RunesId)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)RunesQty.Count);
			foreach (var x in RunesQty)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            BonusMin = reader.ReadFloat();
            BonusMax = reader.ReadFloat();
            var RunesIdCount = reader.ReadShort();
            RunesId = new List<short>();
            for (var i = 0; i < RunesIdCount; i++)
            {
                RunesId.Add(reader.ReadVarShort());
            }
            var RunesQtyCount = reader.ReadShort();
            RunesQty = new List<int>();
            for (var i = 0; i < RunesQtyCount; i++)
            {
                RunesQty.Add(reader.ReadVarInt());
            }
        }
    }
}
