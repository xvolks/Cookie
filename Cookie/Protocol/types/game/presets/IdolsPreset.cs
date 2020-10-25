using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class IdolsPreset : Preset
    {
        public new const short ProtocolId = 491;
        public override short TypeId { get { return ProtocolId; } }

        public short IconId = 0;
        public List<short> IdolIds;

        public IdolsPreset(): base()
        {
        }

        public IdolsPreset(
            short id_,
            short iconId,
            List<short> idolIds
        ): base(
            id_
        )
        {
            IconId = iconId;
            IdolIds = idolIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteShort((short)IdolIds.Count());
            foreach (var current in IdolIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var countIdolIds = reader.ReadShort();
            IdolIds = new List<short>();
            for (short i = 0; i < countIdolIds; i++)
            {
                IdolIds.Add(reader.ReadVarShort());
            }
        }
    }
}