using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class RefreshCharacterStatsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6699;

        public override ushort MessageID => ProtocolId;

        public double FighterId { get; set; }
        public GameFightMinimalStats Stats { get; set; }
        public RefreshCharacterStatsMessage() { }

        public RefreshCharacterStatsMessage( double FighterId, GameFightMinimalStats Stats ){
            this.FighterId = FighterId;
            this.Stats = Stats;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            Stats.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            Stats = new GameFightMinimalStats();
            Stats.Deserialize(reader);
        }
    }
}
