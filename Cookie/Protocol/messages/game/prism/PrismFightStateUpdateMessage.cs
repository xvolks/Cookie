using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightStateUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6040;
        public override uint MessageID { get { return ProtocolId; } }

        public byte State = 0;

        public PrismFightStateUpdateMessage()
        {
        }

        public PrismFightStateUpdateMessage(
            byte state
        )
        {
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            State = reader.ReadByte();
        }
    }
}