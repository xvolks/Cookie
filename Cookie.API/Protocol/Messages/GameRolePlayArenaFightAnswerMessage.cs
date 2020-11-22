using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaFightAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6279;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public bool Accept { get; set; }
        public GameRolePlayArenaFightAnswerMessage() { }

        public GameRolePlayArenaFightAnswerMessage( ushort FightId, bool Accept ){
            this.FightId = FightId;
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            Accept = reader.ReadBoolean();
        }
    }
}
