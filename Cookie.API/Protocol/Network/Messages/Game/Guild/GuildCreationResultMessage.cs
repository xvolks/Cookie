namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5554;
        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public GuildCreationResultMessage(byte result)
        {
            Result = result;
        }

        public GuildCreationResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadByte();
        }

    }
}
