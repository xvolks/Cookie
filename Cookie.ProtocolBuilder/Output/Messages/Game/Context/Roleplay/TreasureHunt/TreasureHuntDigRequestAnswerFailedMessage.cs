namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
    {
        public new const ushort ProtocolId = 6509;
        public override ushort MessageID => ProtocolId;
        public byte WrongFlagCount { get; set; }

        public TreasureHuntDigRequestAnswerFailedMessage(byte wrongFlagCount)
        {
            WrongFlagCount = wrongFlagCount;
        }

        public TreasureHuntDigRequestAnswerFailedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(WrongFlagCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WrongFlagCount = reader.ReadByte();
        }

    }
}
