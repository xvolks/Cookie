using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class DecraftedItemStackInfo : NetworkType
    {
        public const ushort ProtocolId = 481;

        public DecraftedItemStackInfo(uint objectUID, float bonusMin, float bonusMax, List<ushort> runesId,
            List<uint> runesQty)
        {
            ObjectUID = objectUID;
            BonusMin = bonusMin;
            BonusMax = bonusMax;
            RunesId = runesId;
            RunesQty = runesQty;
        }

        public DecraftedItemStackInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint ObjectUID { get; set; }
        public float BonusMin { get; set; }
        public float BonusMax { get; set; }
        public List<ushort> RunesId { get; set; }
        public List<uint> RunesQty { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteFloat(BonusMin);
            writer.WriteFloat(BonusMax);
            writer.WriteShort((short) RunesId.Count);
            for (var runesIdIndex = 0; runesIdIndex < RunesId.Count; runesIdIndex++)
                writer.WriteVarUhShort(RunesId[runesIdIndex]);
            writer.WriteShort((short) RunesQty.Count);
            for (var runesQtyIndex = 0; runesQtyIndex < RunesQty.Count; runesQtyIndex++)
                writer.WriteVarUhInt(RunesQty[runesQtyIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            BonusMin = reader.ReadFloat();
            BonusMax = reader.ReadFloat();
            var runesIdCount = reader.ReadUShort();
            RunesId = new List<ushort>();
            for (var runesIdIndex = 0; runesIdIndex < runesIdCount; runesIdIndex++)
                RunesId.Add(reader.ReadVarUhShort());
            var runesQtyCount = reader.ReadUShort();
            RunesQty = new List<uint>();
            for (var runesQtyIndex = 0; runesQtyIndex < runesQtyCount; runesQtyIndex++)
                RunesQty.Add(reader.ReadVarUhInt());
        }
    }
}