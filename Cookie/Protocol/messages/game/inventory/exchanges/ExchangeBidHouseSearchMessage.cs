using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseSearchMessage : NetworkMessage
    {
        public const uint ProtocolId = 5806;
        public override uint MessageID { get { return ProtocolId; } }

        public int Type = 0;
        public short GenId = 0;

        public ExchangeBidHouseSearchMessage()
        {
        }

        public ExchangeBidHouseSearchMessage(
            int type,
            short genId
        )
        {
            Type = type;
            GenId = genId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Type);
            writer.WriteVarShort(GenId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadVarInt();
            GenId = reader.ReadVarShort();
        }
    }
}