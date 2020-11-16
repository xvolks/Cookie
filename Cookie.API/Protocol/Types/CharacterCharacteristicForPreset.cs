using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterCharacteristicForPreset : SimpleCharacterCharacteristicForPreset
    {
        public new const ushort ProtocolId = 539;

        public override ushort TypeID => ProtocolId;

        public short Stuff { get; set; }
        public CharacterCharacteristicForPreset() { }

        public CharacterCharacteristicForPreset( short Stuff ){
            this.Stuff = Stuff;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Stuff);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Stuff = reader.ReadVarShort();
        }
    }
}
