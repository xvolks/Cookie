using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectMessage : NetworkMessage
    {
        public const uint ProtocolId = 5515;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Remote = false;

        public ExchangeObjectMessage()
        {
        }

        public ExchangeObjectMessage(
            bool remote
        )
        {
            Remote = remote;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Remote);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Remote = reader.ReadBoolean();
        }
    }
}