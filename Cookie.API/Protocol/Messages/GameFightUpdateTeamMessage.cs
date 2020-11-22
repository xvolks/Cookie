using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightUpdateTeamMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5572;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public FightTeamInformations Team { get; set; }
        public GameFightUpdateTeamMessage() { }

        public GameFightUpdateTeamMessage( ushort FightId, FightTeamInformations Team ){
            this.FightId = FightId;
            this.Team = Team;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            Team.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            Team = new FightTeamInformations();
            Team.Deserialize(reader);
        }
    }
}
