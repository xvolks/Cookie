using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    public class CharacterLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5670;

        public CharacterLevelUpMessage(byte newLevel)
        {
            NewLevel = newLevel;
        }

        public CharacterLevelUpMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte NewLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NewLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadByte();
        }
    }
}