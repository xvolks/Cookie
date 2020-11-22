using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicAckMessage : NetworkMessage
    {
        public const uint ProtocolId = 6362;
        public override uint MessageID { get { return ProtocolId; } }

        public int Seq = 0;
        public short LastPacketId = 0;

        public BasicAckMessage()
        {
        }

        public BasicAckMessage(
            int seq,
            short lastPacketId
        )
        {
            Seq = seq;
            LastPacketId = lastPacketId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Seq);
            writer.WriteVarShort(LastPacketId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Seq = reader.ReadVarInt();
            LastPacketId = reader.ReadVarShort();
        }
    }
}