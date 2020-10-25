using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectUseMultipleMessage : ObjectUseMessage
    {
        public new const uint ProtocolId = 6234;
        public override uint MessageID { get { return ProtocolId; } }

        public int Quantity = 0;

        public ObjectUseMultipleMessage(): base()
        {
        }

        public ObjectUseMultipleMessage(
            int objectUID,
            int quantity
        ): base(
            objectUID
        )
        {
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarInt();
        }
    }
}