namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using Utils.IO;

    public class EmoteAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5644;
        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }

        public EmoteAddMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmoteAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
        }

    }
}
