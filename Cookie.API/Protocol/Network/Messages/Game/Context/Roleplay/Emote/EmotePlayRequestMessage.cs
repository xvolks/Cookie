namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using Utils.IO;

    public class EmotePlayRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5685;
        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }

        public EmotePlayRequestMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmotePlayRequestMessage() { }

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
