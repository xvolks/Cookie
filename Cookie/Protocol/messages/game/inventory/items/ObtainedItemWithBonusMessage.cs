using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObtainedItemWithBonusMessage : ObtainedItemMessage
    {
        public new const uint ProtocolId = 6520;
        public override uint MessageID { get { return ProtocolId; } }

        public int BonusQuantity = 0;

        public ObtainedItemWithBonusMessage(): base()
        {
        }

        public ObtainedItemWithBonusMessage(
            short genericId,
            int baseQuantity,
            int bonusQuantity
        ): base(
            genericId,
            baseQuantity
        )
        {
            BonusQuantity = bonusQuantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(BonusQuantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            BonusQuantity = reader.ReadVarInt();
        }
    }
}