using Cookie.API.Utils.IO;

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

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Seq);
            writer.WriteVarUhShort(LastProtocolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Seq = reader.ReadVarUhInt();
            LastProtocolId = reader.ReadVarUhShort();
        }
    }
}