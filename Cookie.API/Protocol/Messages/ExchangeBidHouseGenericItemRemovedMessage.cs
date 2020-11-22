using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5948;

        public override ushort MessageID => ProtocolId;

        public ushort ObjGenericId { get; set; }
        public ExchangeBidHouseGenericItemRemovedMessage() { }

        public ExchangeBidHouseGenericItemRemovedMessage( ushort ObjGenericId ){
            this.ObjGenericId = ObjGenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjGenericId = reader.ReadVarUhShort();
        }
    }
}
