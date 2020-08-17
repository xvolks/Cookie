namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using Utils.IO;

    public class EmotePlayAbstractMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5690;
        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }

        public EmotePlayAbstractMessage(byte emoteId, double emoteStartTime)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public EmotePlayAbstractMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }

    }
}
