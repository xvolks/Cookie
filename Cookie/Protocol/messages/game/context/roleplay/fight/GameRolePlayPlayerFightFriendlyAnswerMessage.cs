using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayPlayerFightFriendlyAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 5732;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public bool Accept = false;

        public GameRolePlayPlayerFightFriendlyAnswerMessage()
        {
        }

        public GameRolePlayPlayerFightFriendlyAnswerMessage(
            short fightId,
            bool accept
        )
        {
            FightId = fightId;
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            Accept = reader.ReadBoolean();
        }
    }
}