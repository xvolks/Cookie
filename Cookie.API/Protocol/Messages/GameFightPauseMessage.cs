using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPauseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6754;

        public override ushort MessageID => ProtocolId;

        public bool IsPaused { get; set; }
        public GameFightPauseMessage() { }

        public GameFightPauseMessage( bool IsPaused ){
            this.IsPaused = IsPaused;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsPaused);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsPaused = reader.ReadBoolean();
        }
    }
}
