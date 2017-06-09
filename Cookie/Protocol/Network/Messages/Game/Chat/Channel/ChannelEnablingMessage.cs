using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Chat.Channel
{
    public class ChannelEnablingMessage : NetworkMessage
    {
        public const uint ProtocolId = 890;
        public override uint MessageID { get { return ProtocolId; } }

        public uint Channel { get; set; }
        public bool Enable { get; set; }

        public ChannelEnablingMessage() { }

        public ChannelEnablingMessage(uint channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte((byte)Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            _channelFunc(reader);
            _enableFunc(reader);
        }

        private void _channelFunc(ICustomDataInput reader)
        {
            Channel = reader.ReadByte();
        }

        private void _enableFunc(ICustomDataInput reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}
