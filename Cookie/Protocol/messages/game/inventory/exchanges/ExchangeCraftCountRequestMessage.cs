using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftCountRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6597;
        public override uint MessageID { get { return ProtocolId; } }

        public int Count = 0;

        public ExchangeCraftCountRequestMessage()
        {
        }

        public ExchangeCraftCountRequestMessage(
            int count
        )
        {
            Count = count;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Count);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Count = reader.ReadVarInt();
        }
    }
}