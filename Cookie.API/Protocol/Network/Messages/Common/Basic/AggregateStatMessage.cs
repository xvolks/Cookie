namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    using Utils.IO;

    public class AggregateStatMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6669;
        public override ushort MessageID => ProtocolId;
        public ushort StatId { get; set; }

        public AggregateStatMessage(ushort statId)
        {
            StatId = statId;
        }

        public AggregateStatMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(StatId);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatId = reader.ReadVarUhShort();
        }

    }
}
