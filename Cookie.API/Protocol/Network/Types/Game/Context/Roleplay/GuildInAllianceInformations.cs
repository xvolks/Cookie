using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GuildInAllianceInformations : GuildInformations
    {
        public new const ushort ProtocolId = 420;

        public GuildInAllianceInformations(byte nbMembers)
        {
            NbMembers = nbMembers;
        }

        public GuildInAllianceInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte NbMembers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbMembers = reader.ReadByte();
        }
    }
}