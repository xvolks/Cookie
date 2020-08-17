namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Utils.IO;

    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public new const ushort ProtocolId = 439;
        public override ushort TypeID => ProtocolId;
        public byte Relation { get; set; }

        public FightAllianceTeamInformations(byte relation)
        {
            Relation = relation;
        }

        public FightAllianceTeamInformations() { }

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
