using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapNoMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 954;

        public override ushort MessageID => ProtocolId;

        public short CellX { get; set; }
        public short CellY { get; set; }
        public GameMapNoMovementMessage() { }

        public GameMapNoMovementMessage( short CellX, short CellY ){
            this.CellX = CellX;
            this.CellY = CellY;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CellX);
            writer.WriteShort(CellY);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellX = reader.ReadShort();
            CellY = reader.ReadShort();
        }
    }
}
