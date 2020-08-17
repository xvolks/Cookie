using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class ServerSettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6340;

        public ServerSettingsMessage(string lang, byte community, sbyte gameType, ushort arenaLeaveBanTime)
        {
            Lang = lang;
            Community = community;
            GameType = gameType;
            ArenaLeaveBanTime = arenaLeaveBanTime;
        }

        public ServerSettingsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Lang { get; set; }
        public byte Community { get; set; }
        public sbyte GameType { get; set; }
        public ushort ArenaLeaveBanTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Lang);
            writer.WriteByte(Community);
            writer.WriteSByte(GameType);
            writer.WriteVarUhShort(ArenaLeaveBanTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Lang = reader.ReadUTF();
            Community = reader.ReadByte();
            GameType = reader.ReadSByte();
            ArenaLeaveBanTime = reader.ReadVarUhShort();
        }
    }
}