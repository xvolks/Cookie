using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightNewRoundMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6239;

        public override ushort MessageID => ProtocolId;

        public uint RoundNumber { get; set; }
        public GameFightNewRoundMessage() { }

        public GameFightNewRoundMessage( uint RoundNumber ){
            this.RoundNumber = RoundNumber;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RoundNumber);
        }

        public override void Deserialize(IDataReader reader)
        {
            RoundNumber = reader.ReadVarUhInt();
        }
    }
}
