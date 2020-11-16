using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextKickMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6081;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public GameContextKickMessage() { }

        public GameContextKickMessage( double TargetId ){
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadDouble();
        }
    }
}
