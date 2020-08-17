namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Types.Updater;
    using Utils.IO;

    public class PartInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1508;
        public override ushort MessageID => ProtocolId;
        public ContentPart Part { get; set; }
        public float InstallationPercent { get; set; }

        public PartInfoMessage(ContentPart part, float installationPercent)
        {
            Part = part;
            InstallationPercent = installationPercent;
        }

        public PartInfoMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Part.Serialize(writer);
            writer.WriteFloat(InstallationPercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            Part = new ContentPart();
            Part.Deserialize(reader);
            InstallationPercent = reader.ReadFloat();
        }

    }
}
