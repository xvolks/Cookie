using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class IdolsPreset : Preset
    {
        public new const ushort ProtocolId = 491;

        public override ushort TypeID => ProtocolId;

        public short IconId { get; set; }
        public List<short> IdolIds { get; set; }
        public IdolsPreset() { }

        public IdolsPreset( short IconId, List<short> IdolIds ){
            this.IconId = IconId;
            this.IdolIds = IdolIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
			writer.WriteShort((short)IdolIds.Count);
			foreach (var x in IdolIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            var IdolIdsCount = reader.ReadShort();
            IdolIds = new List<short>();
            for (var i = 0; i < IdolIdsCount; i++)
            {
                IdolIds.Add(reader.ReadVarShort());
            }
        }
    }
}
