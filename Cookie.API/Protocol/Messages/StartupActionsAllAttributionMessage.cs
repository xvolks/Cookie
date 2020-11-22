using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StartupActionsAllAttributionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6537;

        public override ushort MessageID => ProtocolId;

        public ulong CharacterId { get; set; }
        public StartupActionsAllAttributionMessage() { }

        public StartupActionsAllAttributionMessage( ulong CharacterId ){
            this.CharacterId = CharacterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
        }
    }
}
