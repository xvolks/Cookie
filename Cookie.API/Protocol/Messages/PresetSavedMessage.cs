using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetSavedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6763;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public Preset Preset { get; set; }
        public PresetSavedMessage() { }

        public PresetSavedMessage( short PresetId, Preset Preset ){
            this.PresetId = PresetId;
            this.Preset = Preset;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            Preset.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            Preset = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Preset.Deserialize(reader);
        }
    }
}
