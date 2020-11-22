using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5653;

        public override ushort MessageID => ProtocolId;

        public sbyte JobId { get; set; }
        public ulong PlayerId { get; set; }
        public JobCrafterDirectoryRemoveMessage() { }

        public JobCrafterDirectoryRemoveMessage( sbyte JobId, ulong PlayerId ){
            this.JobId = JobId;
            this.PlayerId = PlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}
