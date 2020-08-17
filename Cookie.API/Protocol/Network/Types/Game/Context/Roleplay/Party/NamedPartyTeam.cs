using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class NamedPartyTeam : NetworkType
    {
        public const ushort ProtocolId = 469;

        public NamedPartyTeam(byte teamId, string partyName)
        {
            TeamId = teamId;
            PartyName = partyName;
        }

        public NamedPartyTeam()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte TeamId { get; set; }
        public string PartyName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TeamId);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeamId = reader.ReadByte();
            PartyName = reader.ReadUTF();
        }
    }
}