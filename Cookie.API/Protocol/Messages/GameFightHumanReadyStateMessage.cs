using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightHumanReadyStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 740;

        public override ushort MessageID => ProtocolId;

        public ulong CharacterId { get; set; }
        public bool IsReady { get; set; }
        public GameFightHumanReadyStateMessage() { }

        public GameFightHumanReadyStateMessage( ulong CharacterId, bool IsReady ){
            this.CharacterId = CharacterId;
            this.IsReady = IsReady;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
            IsReady = reader.ReadBoolean();
        }
    }
}
