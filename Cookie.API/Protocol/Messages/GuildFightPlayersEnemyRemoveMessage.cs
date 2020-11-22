using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5929;

        public override ushort MessageID => ProtocolId;

        public double FightId { get; set; }
        public ulong PlayerId { get; set; }
        public GuildFightPlayersEnemyRemoveMessage() { }

        public GuildFightPlayersEnemyRemoveMessage( double FightId, ulong PlayerId ){
            this.FightId = FightId;
            this.PlayerId = PlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}
