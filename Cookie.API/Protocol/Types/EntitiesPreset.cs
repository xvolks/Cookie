using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class EntitiesPreset : Preset
    {
        public new const ushort ProtocolId = 545;

        public override ushort TypeID => ProtocolId;

        public short IconId { get; set; }
        public List<short> EntityIds { get; set; }
        public EntitiesPreset() { }

        public EntitiesPreset( short IconId, List<short> EntityIds ){
            this.IconId = IconId;
            this.EntityIds = EntityIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
			writer.WriteShort((short)EntityIds.Count);
			foreach (var x in EntityIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var EntityIdsCount = reader.ReadShort();
            EntityIds = new List<short>();
            for (var i = 0; i < EntityIdsCount; i++)
            {
                EntityIds.Add(reader.ReadVarShort());
            }
        }
    }
}
