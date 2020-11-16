using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AlignmentRankUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6058;

        public override ushort MessageID => ProtocolId;

        public sbyte AlignmentRank { get; set; }
        public bool Verbose { get; set; }
        public AlignmentRankUpdateMessage() { }

        public AlignmentRankUpdateMessage( sbyte AlignmentRank, bool Verbose ){
            this.AlignmentRank = AlignmentRank;
            this.Verbose = Verbose;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(AlignmentRank);
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            AlignmentRank = reader.ReadSByte();
            Verbose = reader.ReadBoolean();
        }
    }
}
