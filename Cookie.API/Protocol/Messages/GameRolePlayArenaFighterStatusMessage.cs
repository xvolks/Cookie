using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6281;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public double PlayerId { get; set; }
        public bool Accepted { get; set; }
        public GameRolePlayArenaFighterStatusMessage() { }

        public GameRolePlayArenaFighterStatusMessage( ushort FightId, double PlayerId, bool Accepted ){
            this.FightId = FightId;
            this.PlayerId = PlayerId;
            this.Accepted = Accepted;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteDouble(PlayerId);
            writer.WriteBoolean(Accepted);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            PlayerId = reader.ReadDouble();
            Accepted = reader.ReadBoolean();
        }
    }
}
