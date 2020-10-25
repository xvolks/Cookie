using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SlaveNoLongerControledMessage : NetworkMessage
    {
        public const uint ProtocolId = 6807;
        public override uint MessageID { get { return ProtocolId; } }

        public double MasterId = 0;
        public double SlaveId = 0;

        public SlaveNoLongerControledMessage()
        {
        }

        public SlaveNoLongerControledMessage(
            double masterId,
            double slaveId
        )
        {
            MasterId = masterId;
            SlaveId = slaveId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
        }
    }
}