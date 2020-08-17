namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Utils.IO;

    public class LifePointsRegenBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5684;
        public override ushort MessageID => ProtocolId;
        public byte RegenRate { get; set; }

        public LifePointsRegenBeginMessage(byte regenRate)
        {
            RegenRate = regenRate;
        }

        public LifePointsRegenBeginMessage() { }

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
