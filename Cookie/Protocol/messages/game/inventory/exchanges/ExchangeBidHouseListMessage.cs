using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5807;
        public override uint MessageID { get { return ProtocolId; } }

        public short Id_ = 0;

        public ExchangeBidHouseListMessage()
        {
        }

        public ExchangeBidHouseListMessage(
            short id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
        }
    }
}