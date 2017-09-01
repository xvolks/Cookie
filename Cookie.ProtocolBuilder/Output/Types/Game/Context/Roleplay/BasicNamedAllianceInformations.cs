namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class BasicNamedAllianceInformations : BasicAllianceInformations
    {
        public new const ushort ProtocolId = 418;
        public override ushort TypeID => ProtocolId;
        public string AllianceName { get; set; }

        public BasicNamedAllianceInformations(string allianceName)
        {
            AllianceName = allianceName;
        }

        public BasicNamedAllianceInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(AllianceName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceName = reader.ReadUTF();
        }

    }
}
