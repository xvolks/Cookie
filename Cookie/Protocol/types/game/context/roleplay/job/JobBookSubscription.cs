using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobBookSubscription : NetworkType
    {
        public const short ProtocolId = 500;
        public override short TypeId { get { return ProtocolId; } }

        public byte JobId = 0;
        public bool Subscribed = false;

        public JobBookSubscription()
        {
        }

        public JobBookSubscription(
            byte jobId,
            bool subscribed
        )
        {
            JobId = jobId;
            Subscribed = subscribed;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteBoolean(Subscribed);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            Subscribed = reader.ReadBoolean();
        }
    }
}