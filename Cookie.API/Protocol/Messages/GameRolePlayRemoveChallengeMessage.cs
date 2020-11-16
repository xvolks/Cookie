using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayRemoveChallengeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 300;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public GameRolePlayRemoveChallengeMessage() { }

        public GameRolePlayRemoveChallengeMessage( ushort FightId ){
            this.FightId = FightId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
        }
    }
}
