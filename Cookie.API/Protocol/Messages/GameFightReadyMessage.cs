using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 708;

        public override ushort MessageID => ProtocolId;

        public bool IsReady { get; set; }
        public GameFightReadyMessage() { }

        public GameFightReadyMessage( bool IsReady ){
            this.IsReady = IsReady;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsReady = reader.ReadBoolean();
        }
    }
}
