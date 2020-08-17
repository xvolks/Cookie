using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    public class EmotePlayErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5688;

        public EmotePlayErrorMessage(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public EmotePlayErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte EmoteId { get; set; }

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