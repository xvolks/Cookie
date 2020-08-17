namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
    {
        public new const ushort ProtocolId = 6412;
        public override ushort MessageID => ProtocolId;
        public byte ElementEventId { get; set; }

        public GameContextRemoveElementWithEventMessage(byte elementEventId)
        {
            ElementEventId = elementEventId;
        }

        public GameContextRemoveElementWithEventMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(ElementEventId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ElementEventId = reader.ReadByte();
        }

    }
}
