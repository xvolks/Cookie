using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PartyEntityMemberInformation : PartyEntityBaseInformation
    {
        public new const short ProtocolId = 550;
        public override short TypeId { get { return ProtocolId; } }

        public short Initiative = 0;
        public int LifePoints = 0;
        public int MaxLifePoints = 0;
        public short Prospecting = 0;
        public byte RegenRate = 0;

        public PartyEntityMemberInformation(): base()
        {
        }

        public PartyEntityMemberInformation(
            byte indexId,
            byte entityModelId,
            EntityLook entityLook_,
            short initiative,
            int lifePoints,
            int maxLifePoints,
            short prospecting,
            byte regenRate
        ): base(
            indexId,
            entityModelId,
            entityLook_
        )
        {
            Initiative = initiative;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Initiative);
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
            writer.WriteVarShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarShort();
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
            Prospecting = reader.ReadVarShort();
            RegenRate = reader.ReadByte();
        }
    }
}