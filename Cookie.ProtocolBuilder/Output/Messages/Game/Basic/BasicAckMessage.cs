namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicAckMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6362;
        public override ushort MessageID => ProtocolId;
        public uint Seq { get; set; }
        public ushort LastPacketId { get; set; }

        public BasicAckMessage(uint seq, ushort lastPacketId)
        {
            Seq = seq;
            LastPacketId = lastPacketId;
        }

        public BasicAckMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Seq);
            writer.WriteVarUhShort(LastPacketId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Seq = reader.ReadVarUhInt();
            LastPacketId = reader.ReadVarUhShort();
        }

    }
}
