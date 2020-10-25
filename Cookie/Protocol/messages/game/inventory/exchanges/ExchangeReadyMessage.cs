using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeReadyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5511;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Ready = false;
        public short Step = 0;

        public ExchangeReadyMessage()
        {
        }

        public ExchangeReadyMessage(
            bool ready,
            short step
        )
        {
            Ready = ready;
            Step = step;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Ready);
            writer.WriteVarShort(Step);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Ready = reader.ReadBoolean();
            Step = reader.ReadVarShort();
        }
    }
}