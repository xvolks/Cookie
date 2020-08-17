using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    public class AlignmentRankUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6058;

        public AlignmentRankUpdateMessage(byte alignmentRank, bool verbose)
        {
            AlignmentRank = alignmentRank;
            Verbose = verbose;
        }

        public AlignmentRankUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte AlignmentRank { get; set; }
        public bool Verbose { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(AlignmentRank);
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            AlignmentRank = reader.ReadByte();
            Verbose = reader.ReadBoolean();
        }
    }
}