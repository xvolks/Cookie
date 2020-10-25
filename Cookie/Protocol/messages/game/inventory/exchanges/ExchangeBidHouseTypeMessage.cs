using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseTypeMessage : NetworkMessage
    {
        public const uint ProtocolId = 5803;
        public override uint MessageID { get { return ProtocolId; } }

        public int Type = 0;
        public bool Follow = false;

        public ExchangeBidHouseTypeMessage()
        {
        }

        public ExchangeBidHouseTypeMessage(
            int type,
            bool follow
        )
        {
            Type = type;
            Follow = follow;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Type);
            writer.WriteBoolean(Follow);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadVarInt();
            Follow = reader.ReadBoolean();
        }
    }
}