using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5915;

        public override ushort MessageID => ProtocolId;

        public double CollectorId { get; set; }
        public TaxCollectorMovementRemoveMessage() { }

        public TaxCollectorMovementRemoveMessage( double CollectorId ){
            this.CollectorId = CollectorId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorId = reader.ReadDouble();
        }
    }
}
