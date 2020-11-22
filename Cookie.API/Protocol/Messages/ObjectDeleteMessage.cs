using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectDeleteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3022;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }
        public ObjectDeleteMessage() { }

        public ObjectDeleteMessage( uint ObjectUID, uint Quantity ){
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
