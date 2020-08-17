using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildGetInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5550;

        public GuildGetInformationsMessage(byte infoType)
        {
            InfoType = infoType;
        }

        public GuildGetInformationsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte InfoType { get; set; }

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