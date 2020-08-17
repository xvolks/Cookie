using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 6;

        public FightTeamMemberMonsterInformations(int monsterId, byte grade)
        {
            MonsterId = monsterId;
            Grade = grade;
        }

        public FightTeamMemberMonsterInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int MonsterId { get; set; }
        public byte Grade { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MonsterId);
            writer.WriteByte(Grade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadInt();
            Grade = reader.ReadByte();
        }
    }
}