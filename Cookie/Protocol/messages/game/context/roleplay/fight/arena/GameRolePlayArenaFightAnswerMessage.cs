using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaFightAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6279;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public bool Accept = false;

        public GameRolePlayArenaFightAnswerMessage()
        {
        }

        public GameRolePlayArenaFightAnswerMessage(
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