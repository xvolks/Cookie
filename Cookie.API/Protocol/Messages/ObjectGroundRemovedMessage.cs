using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectGroundRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3014;

        public override ushort MessageID => ProtocolId;

        public ushort Cell { get; set; }
        public ObjectGroundRemovedMessage() { }

        public ObjectGroundRemovedMessage( ushort Cell ){
            this.Cell = Cell;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Cell);
        }

        public override void Deserialize(IDataReader reader)
        {
            Cell = reader.ReadVarUhShort();
        }
    }
}
