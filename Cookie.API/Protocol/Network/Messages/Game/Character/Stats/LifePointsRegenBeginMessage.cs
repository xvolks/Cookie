using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    public class LifePointsRegenBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5684;

        public LifePointsRegenBeginMessage(byte regenRate)
        {
            RegenRate = regenRate;
        }

        public LifePointsRegenBeginMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte RegenRate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            RegenRate = reader.ReadByte();
        }
    }
}