using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectUseOnCharacterMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 3003;

        public override ushort MessageID => ProtocolId;

        public ulong CharacterId { get; set; }
        public ObjectUseOnCharacterMessage() { }

        public ObjectUseOnCharacterMessage( ulong CharacterId ){
            this.CharacterId = CharacterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CharacterId = reader.ReadVarUhLong();
        }
    }
}
