using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChannelEnablingMessage : NetworkMessage
    {
        public const uint ProtocolId = 890;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Channel = 0;
        public bool Enable = false;

        public ChannelEnablingMessage()
        {
        }

        public ChannelEnablingMessage(
            byte channel,
            bool enable
        )
        {
            Channel = channel;
            Enable = enable;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Channel = reader.ReadByte();
            Enable = reader.ReadBoolean();
        }
    }
}