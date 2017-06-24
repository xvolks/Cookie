using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class BasicAckMessage : NetworkMessage
    {
        public const uint ProtocolId = 6362;
        public ushort LastProtocolId;

        public uint Seq;

        public BasicAckMessage()
        {
        }

        public BasicAckMessage(uint seq, ushort lastProtocolId)
        {
            Seq = seq;
            LastProtocolId = lastProtocolId;
        }

        public override uint MessageID => ProtocolId;

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