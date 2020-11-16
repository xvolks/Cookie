using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class RoomAvailableUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6630;

        public override ushort MessageID => ProtocolId;

        public byte NbRoom { get; set; }
        public RoomAvailableUpdateMessage() { }

        public RoomAvailableUpdateMessage( byte NbRoom ){
            this.NbRoom = NbRoom;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NbRoom);
        }

        public override void Deserialize(IDataReader reader)
        {
            NbRoom = reader.ReadByte();
        }
    }
}
