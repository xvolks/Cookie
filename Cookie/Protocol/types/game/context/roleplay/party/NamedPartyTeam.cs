using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class NamedPartyTeam : NetworkType
    {
        public const short ProtocolId = 469;
        public override short TypeId { get { return ProtocolId; } }

        public byte TeamId = 2;
        public string PartyName;

        public NamedPartyTeam()
        {
        }

        public NamedPartyTeam(
            byte teamId,
            string partyName
        )
        {
            TeamId = teamId;
            PartyName = partyName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(TeamId);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TeamId = reader.ReadByte();
            PartyName = reader.ReadUTF();
        }
    }
}