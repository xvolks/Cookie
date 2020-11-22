using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareWonMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6681;

        public override ushort MessageID => ProtocolId;

        public double DareId { get; set; }
        public DareWonMessage() { }

        public DareWonMessage( double DareId ){
            this.DareId = DareId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
        }
    }
}
