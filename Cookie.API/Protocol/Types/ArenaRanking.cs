using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ArenaRanking : NetworkType
    {
        public const ushort ProtocolId = 554;

        public override ushort TypeID => ProtocolId;

        public ushort Rank { get; set; }
        public ushort BestRank { get; set; }
        public ArenaRanking() { }

        public ArenaRanking( ushort Rank, ushort BestRank ){
            this.Rank = Rank;
            this.BestRank = BestRank;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Rank);
            writer.WriteVarUhShort(BestRank);
        }

        public override void Deserialize(IDataReader reader)
        {
            Rank = reader.ReadVarUhShort();
            BestRank = reader.ReadVarUhShort();
        }
    }
}
