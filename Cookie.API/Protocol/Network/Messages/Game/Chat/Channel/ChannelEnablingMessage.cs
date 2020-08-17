using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Channel
{
    public class ChannelEnablingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 890;

        public ChannelEnablingMessage(byte channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public ChannelEnablingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Channel { get; set; }
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Channel = reader.ReadByte();
            Enable = reader.ReadBoolean();
        }
    }
}