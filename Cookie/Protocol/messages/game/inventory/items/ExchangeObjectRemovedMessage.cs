using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectRemovedMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 5517;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;

        public ExchangeObjectRemovedMessage(): base()
        {
        }

        public ExchangeObjectRemovedMessage(
            bool remote,
            int objectUID
        ): base(
            remote
        )
        {
            ObjectUID = objectUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(ObjectUID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarInt();
        }
    }
}