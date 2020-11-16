using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectQuantityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3023;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }
        public sbyte Origin { get; set; }
        public ObjectQuantityMessage() { }

        public ObjectQuantityMessage( uint ObjectUID, uint Quantity, sbyte Origin ){
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
            this.Origin = Origin;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
            writer.WriteSByte(Origin);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
            Origin = reader.ReadSByte();
        }
    }
}
