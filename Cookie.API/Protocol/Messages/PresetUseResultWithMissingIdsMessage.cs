using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
    {
        public new const ushort ProtocolId = 6757;

        public override ushort MessageID => ProtocolId;

        public List<short> MissingIds { get; set; }
        public PresetUseResultWithMissingIdsMessage() { }

        public PresetUseResultWithMissingIdsMessage( List<short> MissingIds ){
            this.MissingIds = MissingIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)MissingIds.Count);
			foreach (var x in MissingIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var MissingIdsCount = reader.ReadShort();
            MissingIds = new List<short>();
            for (var i = 0; i < MissingIdsCount; i++)
            {
                MissingIds.Add(reader.ReadVarShort());
            }
        }
    }
}
