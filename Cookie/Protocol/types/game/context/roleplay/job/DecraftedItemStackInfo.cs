using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class DecraftedItemStackInfo : NetworkType
    {
        public const short ProtocolId = 481;
        public override short TypeId { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public float BonusMin = 0;
        public float BonusMax = 0;
        public List<short> RunesId;
        public List<int> RunesQty;

        public DecraftedItemStackInfo()
        {
        }

        public DecraftedItemStackInfo(
            int objectUID,
            float bonusMin,
            float bonusMax,
            List<short> runesId,
            List<int> runesQty
        )
        {
            ObjectUID = objectUID;
            BonusMin = bonusMin;
            BonusMax = bonusMax;
            RunesId = runesId;
            RunesQty = runesQty;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteFloat(BonusMin);
            writer.WriteFloat(BonusMax);
            writer.WriteShort((short)RunesId.Count());
            foreach (var current in RunesId)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)RunesQty.Count());
            foreach (var current in RunesQty)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            BonusMin = reader.ReadFloat();
            BonusMax = reader.ReadFloat();
            var countRunesId = reader.ReadShort();
            RunesId = new List<short>();
            for (short i = 0; i < countRunesId; i++)
            {
                RunesId.Add(reader.ReadVarShort());
            }
            var countRunesQty = reader.ReadShort();
            RunesQty = new List<int>();
            for (short i = 0; i < countRunesQty; i++)
            {
                RunesQty.Add(reader.ReadVarInt());
            }
        }
    }
}