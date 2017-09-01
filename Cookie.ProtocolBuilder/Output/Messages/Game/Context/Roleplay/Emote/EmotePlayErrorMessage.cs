namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using Utils.IO;

    public class EmotePlayErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5688;
        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }

        public EmotePlayErrorMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmotePlayErrorMessage() { }

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
