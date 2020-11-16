using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachRewardBoughtMessage : NetworkMessage
    {
        public const uint ProtocolId = 6797;
        public override uint MessageID { get { return ProtocolId; } }

        public int Id_ = 0;
        public bool Bought = false;

        public BreachRewardBoughtMessage()
        {
        }

        public BreachRewardBoughtMessage(
            int id_,
            bool bought
        )
        {
            Id_ = id_;
            Bought = bought;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Id_);
            writer.WriteBoolean(Bought);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarInt();
            Bought = reader.ReadBoolean();
        }
    }
}