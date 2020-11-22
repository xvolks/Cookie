using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 721;

        public override ushort MessageID => ProtocolId;

        public double CharId { get; set; }
        public GameFightLeaveMessage() { }

        public GameFightLeaveMessage( double CharId ){
            this.CharId = CharId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharId = reader.ReadDouble();
        }
    }
}
