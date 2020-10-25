using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterBuildPreset : PresetsContainerPreset
    {
        public new const short ProtocolId = 534;
        public override short TypeId { get { return ProtocolId; } }

        public short IconId = 0;
        public string Name;

        public CharacterBuildPreset(): base()
        {
        }

        public CharacterBuildPreset(
            short id_,
            List<Preset> presets,
            short iconId,
            string name
        ): base(
            id_,
            presets
        )
        {
            IconId = iconId;
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(IconId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            IconId = reader.ReadShort();
            Name = reader.ReadUTF();
        }
    }
}