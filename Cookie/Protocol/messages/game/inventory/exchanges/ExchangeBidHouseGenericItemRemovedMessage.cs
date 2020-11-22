using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5948;
        public override uint MessageID { get { return ProtocolId; } }

        public short ObjGenericId = 0;

        public ExchangeBidHouseGenericItemRemovedMessage()
        {
        }

        public ExchangeBidHouseGenericItemRemovedMessage(
            short objGenericId
        )
        {
            ObjGenericId = objGenericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ObjGenericId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjGenericId = reader.ReadVarShort();
        }
    }
}