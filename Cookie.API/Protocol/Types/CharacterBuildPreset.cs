using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterBuildPreset : PresetsContainerPreset
    {
        public new const ushort ProtocolId = 534;

        public override ushort TypeID => ProtocolId;

        public short IconId { get; set; }
        public string Name { get; set; }
        public CharacterBuildPreset() { }

        public CharacterBuildPreset( short IconId, string Name ){
            this.IconId = IconId;
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            Name = reader.ReadUTF();
        }
    }
}
