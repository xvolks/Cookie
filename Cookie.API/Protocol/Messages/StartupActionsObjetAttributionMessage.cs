using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StartupActionsObjetAttributionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1303;

        public override ushort MessageID => ProtocolId;

        public int ActionId { get; set; }
        public ulong CharacterId { get; set; }
        public StartupActionsObjetAttributionMessage() { }

        public StartupActionsObjetAttributionMessage( int ActionId, ulong CharacterId ){
            this.ActionId = ActionId;
            this.CharacterId = CharacterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ActionId);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadInt();
            CharacterId = reader.ReadVarUhLong();
        }
    }
}
