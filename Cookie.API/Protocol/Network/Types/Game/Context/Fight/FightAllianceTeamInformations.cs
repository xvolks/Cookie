using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public new const ushort ProtocolId = 439;

        public FightAllianceTeamInformations(byte relation)
        {
            Relation = relation;
        }

        public FightAllianceTeamInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Relation { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Relation);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Relation = reader.ReadByte();
        }
    }
}