namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Channel
{
    using Utils.IO;

    public class ChannelEnablingChangeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 891;
        public override ushort MessageID => ProtocolId;
        public byte Channel { get; set; }
        public bool Enable { get; set; }

        public ChannelEnablingChangeMessage(byte channel, bool enable)
        {
            Channel = channel;
            Enable = enable;
        }

        public ChannelEnablingChangeMessage() { }

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
