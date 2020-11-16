using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class EntitiesPreset : Preset
    {
        public new const short ProtocolId = 545;
        public override short TypeId { get { return ProtocolId; } }

        public short IconId = 0;
        public List<short> EntityIds;

        public EntitiesPreset(): base()
        {
        }

        public EntitiesPreset(
            short id_,
            short iconId,
            List<short> entityIds
        ): base(
            id_
        )
        {
            IconId = iconId;
            EntityIds = entityIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteShort((short)EntityIds.Count());
            foreach (var current in EntityIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var countEntityIds = reader.ReadShort();
            EntityIds = new List<short>();
            for (short i = 0; i < countEntityIds; i++)
            {
                EntityIds.Add(reader.ReadVarShort());
            }
        }
    }
}