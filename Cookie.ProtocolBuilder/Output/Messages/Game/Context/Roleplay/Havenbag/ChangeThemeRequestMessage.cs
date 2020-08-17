namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class ChangeThemeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6639;
        public override ushort MessageID => ProtocolId;
        public sbyte Theme { get; set; }

        public ChangeThemeRequestMessage(sbyte theme)
        {
            Theme = theme;
        }

        public ChangeThemeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Theme);
        }

        public override void Deserialize(IDataReader reader)
        {
            Theme = reader.ReadSByte();
        }

    }
}
