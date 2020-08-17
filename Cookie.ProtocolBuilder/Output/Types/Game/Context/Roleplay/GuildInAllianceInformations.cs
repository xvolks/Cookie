namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildInAllianceInformations : GuildInformations
    {
        public new const ushort ProtocolId = 420;
        public override ushort TypeID => ProtocolId;
        public byte NbMembers { get; set; }

        public GuildInAllianceInformations(byte nbMembers)
        {
            NbMembers = nbMembers;
        }

        public GuildInAllianceInformations() { }

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
