using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightSpectatePlayerRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6474;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public GameFightSpectatePlayerRequestMessage() { }

        public GameFightSpectatePlayerRequestMessage( ulong PlayerId ){
            this.PlayerId = PlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
        }
    }
}
