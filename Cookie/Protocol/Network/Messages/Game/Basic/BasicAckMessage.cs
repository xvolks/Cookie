using Cookie.IO;
namespace Cookie.Protocol.Network.Messages.Game.Basic
{
    class BasicAckMessage : NetworkMessage
    {
        public const uint ProtocolId = 6362;
        public override uint MessageID { get { return ProtocolId; } }

        public uint Seq;
        public ushort LastProtocolId;

        public BasicAckMessage() { }

        public BasicAckMessage(uint seq, ushort lastProtocolId)
        {
            Seq = seq;
            LastProtocolId = lastProtocolId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhInt(Seq);
            writer.WriteVarUhShort(LastProtocolId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Seq = reader.ReadVarUhInt();
            LastProtocolId = reader.ReadVarUhShort();
        }
    }
}
