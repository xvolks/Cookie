using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 6010;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;

        public ExchangeObjectRemovedFromBagMessage(): base()
        {
        }

        public ExchangeObjectRemovedFromBagMessage(
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