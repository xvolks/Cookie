using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapChangeOrientationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 945;

        public override ushort MessageID => ProtocolId;

        public sbyte Direction { get; set; }
        public GameMapChangeOrientationRequestMessage() { }

        public GameMapChangeOrientationRequestMessage( sbyte Direction ){
            this.Direction = Direction;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            Direction = reader.ReadSByte();
        }
    }
}
