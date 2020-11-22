using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3010;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public short Position { get; set; }
        public ObjectMovementMessage() { }

        public ObjectMovementMessage( uint ObjectUID, short Position ){
            this.ObjectUID = ObjectUID;
            this.Position = Position;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteShort(Position);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Position = reader.ReadShort();
        }
    }
}
