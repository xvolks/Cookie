using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachRewardBuyMessage : NetworkMessage
    {
        public const uint ProtocolId = 6803;
        public override uint MessageID { get { return ProtocolId; } }

        public int Id_ = 0;

        public BreachRewardBuyMessage()
        {
        }

        public BreachRewardBuyMessage(
            int id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarInt();
        }
    }
}