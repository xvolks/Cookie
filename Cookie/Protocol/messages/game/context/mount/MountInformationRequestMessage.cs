using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountInformationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5972;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;
        public double Time = 0;

        public MountInformationRequestMessage()
        {
        }

        public MountInformationRequestMessage(
            double id_,
            double time
        )
        {
            Id_ = id_;
            Time = time;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
            writer.WriteDouble(Time);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
            Time = reader.ReadDouble();
        }
    }
}