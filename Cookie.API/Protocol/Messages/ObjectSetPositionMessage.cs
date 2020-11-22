using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectSetPositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3021;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public short Position { get; set; }
        public uint Quantity { get; set; }
        public ObjectSetPositionMessage() { }

        public ObjectSetPositionMessage( uint ObjectUID, short Position, uint Quantity ){
            this.ObjectUID = ObjectUID;
            this.Position = Position;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteShort(Position);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Position = reader.ReadShort();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
