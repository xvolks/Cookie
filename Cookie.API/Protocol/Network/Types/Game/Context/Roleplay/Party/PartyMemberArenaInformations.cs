using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class PartyMemberArenaInformations : PartyMemberInformations
    {
        public new const ushort ProtocolId = 391;

        public PartyMemberArenaInformations(ushort rank)
        {
            Rank = rank;
        }

        public PartyMemberArenaInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Rank { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Rank);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarUhShort();
        }
    }
}