using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    class ServerSettingsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6340;
        public override uint MessageID { get { return ProtocolId; } }

        public string Lang;
        public byte Community;
        public byte GameType;
        public ushort ArenaLeaveBanTime;

        public ServerSettingsMessage() { }

        public ServerSettingsMessage(string lang, byte community, byte gameType, ushort arenaLeaveBanTime)
        {
            Lang = lang;
            Community = community;
            GameType = gameType;
            ArenaLeaveBanTime = arenaLeaveBanTime;
        }

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
