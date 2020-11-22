using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public new const ushort ProtocolId = 861;

        public override ushort MessageID => ProtocolId;

        public sbyte Channel { get; set; }
        public ChatClientMultiMessage() { }

        public ChatClientMultiMessage( sbyte Channel ){
            this.Channel = Channel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Channel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Channel = reader.ReadSByte();
        }
    }
}
