using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class ServerSettingsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6340;
        public ushort ArenaLeaveBanTime;
        public byte Community;
        public byte GameType;

        public string Lang;

        public ServerSettingsMessage()
        {
        }

        public ServerSettingsMessage(string lang, byte community, byte gameType, ushort arenaLeaveBanTime)
        {
            Lang = lang;
            Community = community;
            GameType = gameType;
            ArenaLeaveBanTime = arenaLeaveBanTime;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Lang);
            writer.WriteByte(Community);
            writer.WriteByte(GameType);
            writer.WriteVarUhShort(ArenaLeaveBanTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Lang = reader.ReadUTF();
            Community = reader.ReadByte();
            GameType = reader.ReadByte();
            ArenaLeaveBanTime = reader.ReadVarUhShort();
        }
    }
}