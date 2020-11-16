using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 445;

        public override ushort TypeID => ProtocolId;

        public BasicGuildInformations Guild { get; set; }
        public CharacterMinimalGuildInformations() { }

        public CharacterMinimalGuildInformations( BasicGuildInformations Guild ){
            this.Guild = Guild;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}
