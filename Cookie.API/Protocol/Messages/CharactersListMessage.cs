using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const ushort ProtocolId = 151;

        public override ushort MessageID => ProtocolId;

        public bool HasStartupActions { get; set; }
        public CharactersListMessage() { }

        public CharactersListMessage( bool HasStartupActions ){
            this.HasStartupActions = HasStartupActions;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(HasStartupActions);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HasStartupActions = reader.ReadBoolean();
        }
    }
}
