using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayRemoveChallengeMessage : NetworkMessage
    {
        public const uint ProtocolId = 300;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;

        public GameRolePlayRemoveChallengeMessage()
        {
        }

        public GameRolePlayRemoveChallengeMessage(
            short fightId
        )
        {
            FightId = fightId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
        }
    }
}