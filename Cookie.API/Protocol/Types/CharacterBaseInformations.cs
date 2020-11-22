using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 45;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public CharacterBaseInformations() { }

        public CharacterBaseInformations( bool Sex ){
            this.Sex = Sex;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Sex = reader.ReadBoolean();
        }
    }
}
