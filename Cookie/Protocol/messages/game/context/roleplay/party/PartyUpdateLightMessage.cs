using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyUpdateLightMessage : AbstractPartyEventMessage
    {
        public new const uint ProtocolId = 6054;
        public override uint MessageID { get { return ProtocolId; } }

        public long Id_ = 0;
        public int LifePoints = 0;
        public int MaxLifePoints = 0;
        public short Prospecting = 0;
        public byte RegenRate = 0;

        public PartyUpdateLightMessage(): base()
        {
        }

        public PartyUpdateLightMessage(
            int partyId,
            long id_,
            int lifePoints,
            int maxLifePoints,
            short prospecting,
            byte regenRate
        ): base(
            partyId
        )
        {
            Id_ = id_;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Id_);
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
            writer.WriteVarShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Id_ = reader.ReadVarLong();
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
            Prospecting = reader.ReadVarShort();
            RegenRate = reader.ReadByte();
        }
    }
}