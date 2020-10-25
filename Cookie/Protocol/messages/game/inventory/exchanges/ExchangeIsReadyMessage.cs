using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeIsReadyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5509;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;
        public bool Ready = false;

        public ExchangeIsReadyMessage()
        {
        }

        public ExchangeIsReadyMessage(
            double id_,
            bool ready
        )
        {
            Id_ = id_;
            Ready = ready;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
            writer.WriteBoolean(Ready);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
            Ready = reader.ReadBoolean();
        }
    }
}