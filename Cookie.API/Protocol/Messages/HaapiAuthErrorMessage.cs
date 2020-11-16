using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HaapiAuthErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6768;

        public override ushort MessageID => ProtocolId;

        public sbyte Type { get; set; }
        public HaapiAuthErrorMessage() { }

        public HaapiAuthErrorMessage( sbyte Type ){
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
        }
    }
}
