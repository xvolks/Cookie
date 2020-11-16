using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public new const short ProtocolId = 3;
        public override short TypeId { get { return ProtocolId; } }

        public short MonsterId = 0;
        public byte PowerLevel = 0;

        public GameRolePlayMutantInformations(): base()
        {
        }

        public GameRolePlayMutantInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name,
            HumanInformations humanoidInfo,
            int accountId,
            short monsterId,
            byte powerLevel
        ): base(
            contextualId,
            look,
            disposition,
            name,
            humanoidInfo,
            accountId
        )
        {
            MonsterId = monsterId;
            PowerLevel = powerLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(MonsterId);
            writer.WriteByte(PowerLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadVarShort();
            PowerLevel = reader.ReadByte();
        }
    }
}