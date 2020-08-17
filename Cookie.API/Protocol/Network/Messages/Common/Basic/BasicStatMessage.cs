namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    using Utils.IO;

    public class BasicStatMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6530;
        public override ushort MessageID => ProtocolId;
        public double TimeSpent { get; set; }
        public ushort StatId { get; set; }

        public BasicStatMessage(double timeSpent, ushort statId)
        {
            TimeSpent = timeSpent;
            StatId = statId;
        }

        public BasicStatMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TimeSpent);
            writer.WriteVarUhShort(StatId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TimeSpent = reader.ReadDouble();
            StatId = reader.ReadVarUhShort();
        }

    }
}
