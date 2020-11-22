using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
    {
        public new const short ProtocolId = 6;
        public override short TypeId { get { return ProtocolId; } }

        public int MonsterId = 0;
        public byte Grade = 0;

        public FightTeamMemberMonsterInformations(): base()
        {
        }

        public FightTeamMemberMonsterInformations(
            double id_,
            int monsterId,
            byte grade
        ): base(
            id_
        )
        {
            MonsterId = monsterId;
            Grade = grade;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MonsterId);
            writer.WriteByte(Grade);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadInt();
            Grade = reader.ReadByte();
        }
    }
}