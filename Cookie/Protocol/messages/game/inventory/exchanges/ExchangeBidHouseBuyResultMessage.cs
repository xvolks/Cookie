using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseBuyResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6272;
        public override uint MessageID { get { return ProtocolId; } }

        public int Uid = 0;
        public bool Bought = false;

        public ExchangeBidHouseBuyResultMessage()
        {
        }

        public ExchangeBidHouseBuyResultMessage(
            int uid,
            bool bought
        )
        {
            Uid = uid;
            Bought = bought;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Uid);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Uid = reader.ReadVarInt();
            Bought = reader.ReadBoolean();
        }
    }
}