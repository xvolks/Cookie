namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildGetInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5550;
        public override ushort MessageID => ProtocolId;
        public byte InfoType { get; set; }

        public GuildGetInformationsMessage(byte infoType)
        {
            InfoType = infoType;
        }

        public GuildGetInformationsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(InfoType);
        }

        public override void Deserialize(IDataReader reader)
        {
            InfoType = reader.ReadByte();
        }

    }
}
