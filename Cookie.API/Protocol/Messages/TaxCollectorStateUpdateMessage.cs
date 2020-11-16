using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6455;

        public override ushort MessageID => ProtocolId;

        public double UniqueId { get; set; }
        public sbyte State { get; set; }
        public TaxCollectorStateUpdateMessage() { }

        public TaxCollectorStateUpdateMessage( double UniqueId, sbyte State ){
            this.UniqueId = UniqueId;
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            UniqueId = reader.ReadDouble();
            State = reader.ReadSByte();
        }
    }
}
