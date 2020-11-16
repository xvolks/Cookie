using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightRemoveTeamMemberMessage : NetworkMessage
    {
        public const ushort ProtocolId = 711;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public sbyte TeamId { get; set; }
        public double CharId { get; set; }
        public GameFightRemoveTeamMemberMessage() { }

        public GameFightRemoveTeamMemberMessage( ushort FightId, sbyte TeamId, double CharId ){
            this.FightId = FightId;
            this.TeamId = TeamId;
            this.CharId = CharId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteSByte(TeamId);
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            TeamId = reader.ReadSByte();
            CharId = reader.ReadDouble();
        }
    }
}
