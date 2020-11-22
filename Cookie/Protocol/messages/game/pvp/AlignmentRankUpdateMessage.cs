using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AlignmentRankUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6058;
        public override uint MessageID { get { return ProtocolId; } }

        public byte AlignmentRank = 0;
        public bool Verbose = false;

        public AlignmentRankUpdateMessage()
        {
        }

        public AlignmentRankUpdateMessage(
            byte alignmentRank,
            bool verbose
        )
        {
            AlignmentRank = alignmentRank;
            Verbose = verbose;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(AlignmentRank);
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AlignmentRank = reader.ReadByte();
            Verbose = reader.ReadBoolean();
        }
    }
}