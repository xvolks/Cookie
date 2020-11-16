using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SequenceNumberMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6317;

        public override ushort MessageID => ProtocolId;

        public ushort Number { get; set; }
        public SequenceNumberMessage() { }

        public SequenceNumberMessage( ushort Number ){
            this.Number = Number;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUnsignedShort(Number);
        }

        public override void Deserialize(IDataReader reader)
        {
            Number = reader.ReadUnsignedShort();
        }
    }
}
