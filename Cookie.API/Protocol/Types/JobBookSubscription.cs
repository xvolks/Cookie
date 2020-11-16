using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobBookSubscription : NetworkType
    {
        public const ushort ProtocolId = 500;

        public override ushort TypeID => ProtocolId;

        public sbyte JobId { get; set; }
        public bool Subscribed { get; set; }
        public JobBookSubscription() { }

        public JobBookSubscription( sbyte JobId, bool Subscribed ){
            this.JobId = JobId;
            this.Subscribed = Subscribed;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteBoolean(Subscribed);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            Subscribed = reader.ReadBoolean();
        }
    }
}
