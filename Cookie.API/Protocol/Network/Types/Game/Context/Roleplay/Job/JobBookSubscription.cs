using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobBookSubscription : NetworkType
    {
        public const ushort ProtocolId = 500;

        public JobBookSubscription(byte jobId, bool subscribed)
        {
            JobId = jobId;
            Subscribed = subscribed;
        }

        public JobBookSubscription()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte JobId { get; set; }
        public bool Subscribed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteBoolean(Subscribed);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            Subscribed = reader.ReadBoolean();
        }
    }
}