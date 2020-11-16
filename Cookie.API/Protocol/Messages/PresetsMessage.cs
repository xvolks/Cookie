using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6750;

        public override ushort MessageID => ProtocolId;

        public List<Preset> Presets { get; set; }
        public PresetsMessage() { }

        public PresetsMessage( List<Preset> Presets ){
            this.Presets = Presets;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Presets.Count);
			foreach (var x in Presets)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PresetsCount = reader.ReadShort();
            Presets = new List<Preset>();
            for (var i = 0; i < PresetsCount; i++)
            {
                Preset objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Presets.Add(objectToAdd);
            }
        }
    }
}
