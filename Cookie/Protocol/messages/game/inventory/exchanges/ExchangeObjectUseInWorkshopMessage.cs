using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectUseInWorkshopMessage : NetworkMessage
    {
        public const uint ProtocolId = 6004;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public int Quantity = 0;

        public ExchangeObjectUseInWorkshopMessage()
        {
        }

        public ExchangeObjectUseInWorkshopMessage(
            int objectUID,
            int quantity
        )
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}