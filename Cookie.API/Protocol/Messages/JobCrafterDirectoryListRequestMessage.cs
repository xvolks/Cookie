using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6047;

        public override ushort MessageID => ProtocolId;

        public sbyte JobId { get; set; }
        public JobCrafterDirectoryListRequestMessage() { }

        public JobCrafterDirectoryListRequestMessage( sbyte JobId ){
            this.JobId = JobId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
        }
    }
}
