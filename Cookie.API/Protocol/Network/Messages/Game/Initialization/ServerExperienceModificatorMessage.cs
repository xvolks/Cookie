namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    using Utils.IO;

    public class ServerExperienceModificatorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6237;
        public override ushort MessageID => ProtocolId;
        public ushort ExperiencePercent { get; set; }

        public ServerExperienceModificatorMessage(ushort experiencePercent)
        {
            ExperiencePercent = experiencePercent;
        }

        public ServerExperienceModificatorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ExperiencePercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencePercent = reader.ReadVarUhShort();
        }

    }
}
