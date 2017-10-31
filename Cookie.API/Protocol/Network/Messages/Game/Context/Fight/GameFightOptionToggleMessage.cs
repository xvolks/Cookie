namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightOptionToggleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 707;
        public override ushort MessageID => ProtocolId;
        public byte Option { get; set; }

        public GameFightOptionToggleMessage(byte option)
        {
            Option = option;
        }

        public GameFightOptionToggleMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Option);
        }

        public override void Deserialize(IDataReader reader)
        {
            Option = reader.ReadByte();
        }

    }
}
