using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PartyIdol : Idol
    {
        public new const short ProtocolId = 490;
        public override short TypeId { get { return ProtocolId; } }

        public List<long> OwnersIds;

        public PartyIdol(): base()
        {
        }

        public PartyIdol(
            short id_,
            short xpBonusPercent,
            short dropBonusPercent,
            List<long> ownersIds
        ): base(
            id_,
            xpBonusPercent,
            dropBonusPercent
        )
        {
            OwnersIds = ownersIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)OwnersIds.Count());
            foreach (var current in OwnersIds)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countOwnersIds = reader.ReadShort();
            OwnersIds = new List<long>();
            for (short i = 0; i < countOwnersIds; i++)
            {
                OwnersIds.Add(reader.ReadVarLong());
            }
        }
    }
}