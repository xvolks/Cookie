using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class OrnamentSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6370;

        public override ushort MessageID => ProtocolId;

        public sbyte Reason { get; set; }
        public OrnamentSelectErrorMessage() { }

        public OrnamentSelectErrorMessage( sbyte Reason ){
            this.Reason = Reason;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }
    }
}
