using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismInfoInValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5859;

        public override ushort MessageID => ProtocolId;

        public sbyte Reason { get; set; }
        public PrismInfoInValidMessage() { }

        public PrismInfoInValidMessage( sbyte Reason ){
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
