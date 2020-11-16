using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ShortcutObjectIdolsPreset : ShortcutObject
    {
        public new const ushort ProtocolId = 492;

        public override ushort TypeID => ProtocolId;

        public short PresetId { get; set; }
        public ShortcutObjectIdolsPreset() { }

        public ShortcutObjectIdolsPreset( short PresetId ){
            this.PresetId = PresetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PresetId = reader.ReadShort();
        }
    }
}
