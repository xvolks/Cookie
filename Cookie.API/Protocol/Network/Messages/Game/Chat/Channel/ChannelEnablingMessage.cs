using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Channel
{
    public class ChannelEnablingMessage : NetworkMessage
    {
        public const uint ProtocolId = 890;

        public ChannelEnablingMessage()
        {
        }

        public ChannelEnablingMessage(uint channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public override uint MessageID => ProtocolId;

        public uint Channel { get; set; }
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte((byte) Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            _channelFunc(reader);
            _enableFunc(reader);
        }

        private void _channelFunc(IDataReader reader)
        {
            Channel = reader.ReadByte();
        }

        private void _enableFunc(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}