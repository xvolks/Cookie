using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChannelEnablingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 890;

        public override ushort MessageID => ProtocolId;

        public sbyte Channel { get; set; }
        public bool Enable { get; set; }
        public ChannelEnablingMessage() { }

        public ChannelEnablingMessage( sbyte Channel, bool Enable ){
            this.Channel = Channel;
            this.Enable = Enable;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Channel);
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Channel = reader.ReadSByte();
            Enable = reader.ReadBoolean();
        }
    }
}
