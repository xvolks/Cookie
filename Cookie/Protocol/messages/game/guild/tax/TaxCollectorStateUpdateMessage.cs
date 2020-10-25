using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6455;
        public override uint MessageID { get { return ProtocolId; } }

        public double UniqueId = 0;
        public byte State = 0;

        public TaxCollectorStateUpdateMessage()
        {
        }

        public TaxCollectorStateUpdateMessage(
            double uniqueId,
            byte state
        )
        {
            UniqueId = uniqueId;
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteByte(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            UniqueId = reader.ReadDouble();
            State = reader.ReadByte();
        }
    }
}