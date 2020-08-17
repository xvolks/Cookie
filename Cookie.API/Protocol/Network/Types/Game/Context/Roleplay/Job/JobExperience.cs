using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobExperience : NetworkType
    {
        public const ushort ProtocolId = 98;

        public JobExperience(byte jobId, byte jobLevel, ulong jobXP, ulong jobXpLevelFloor, ulong jobXpNextLevelFloor)
        {
            JobId = jobId;
            JobLevel = jobLevel;
            JobXP = jobXP;
            JobXpLevelFloor = jobXpLevelFloor;
            JobXpNextLevelFloor = jobXpNextLevelFloor;
        }

        public JobExperience()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte JobId { get; set; }
        public byte JobLevel { get; set; }
        public ulong JobXP { get; set; }
        public ulong JobXpLevelFloor { get; set; }
        public ulong JobXpNextLevelFloor { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteVarUhLong(JobXP);
            writer.WriteVarUhLong(JobXpLevelFloor);
            writer.WriteVarUhLong(JobXpNextLevelFloor);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            JobLevel = reader.ReadByte();
            JobXP = reader.ReadVarUhLong();
            JobXpLevelFloor = reader.ReadVarUhLong();
            JobXpNextLevelFloor = reader.ReadVarUhLong();
        }
    }
}