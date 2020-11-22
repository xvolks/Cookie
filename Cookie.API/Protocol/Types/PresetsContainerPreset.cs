using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PresetsContainerPreset : Preset
    {
        public new const ushort ProtocolId = 520;

        public override ushort TypeID => ProtocolId;

        public List<Preset> Presets { get; set; }
        public PresetsContainerPreset() { }

        public PresetsContainerPreset( List<Preset> Presets ){
            this.Presets = Presets;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Presets.Count);
			foreach (var x in Presets)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
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
