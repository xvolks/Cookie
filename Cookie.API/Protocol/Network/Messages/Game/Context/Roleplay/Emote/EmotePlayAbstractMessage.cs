using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    public class EmotePlayAbstractMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5690;

        public EmotePlayAbstractMessage(byte emoteId, double emoteStartTime)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public EmotePlayAbstractMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }

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