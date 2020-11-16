using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobExperience : NetworkType
    {
        public const ushort ProtocolId = 98;

        public override ushort TypeID => ProtocolId;

        public sbyte JobId { get; set; }
        public byte JobLevel { get; set; }
        public ulong JobXP { get; set; }
        public ulong JobXpLevelFloor { get; set; }
        public ulong JobXpNextLevelFloor { get; set; }
        public JobExperience() { }

        public JobExperience( sbyte JobId, byte JobLevel, ulong JobXP, ulong JobXpLevelFloor, ulong JobXpNextLevelFloor ){
            this.JobId = JobId;
            this.JobLevel = JobLevel;
            this.JobXP = JobXP;
            this.JobXpLevelFloor = JobXpLevelFloor;
            this.JobXpNextLevelFloor = JobXpNextLevelFloor;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteVarUhLong(JobXP);
            writer.WriteVarUhLong(JobXpLevelFloor);
            writer.WriteVarUhLong(JobXpNextLevelFloor);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            JobLevel = reader.ReadByte();
            JobXP = reader.ReadVarUhLong();
            JobXpLevelFloor = reader.ReadVarUhLong();
            JobXpNextLevelFloor = reader.ReadVarUhLong();
        }
    }
}
