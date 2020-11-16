using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaRegisterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6280;
        public override uint MessageID { get { return ProtocolId; } }

        public int BattleMode = 3;

        public GameRolePlayArenaRegisterMessage()
        {
        }

        public GameRolePlayArenaRegisterMessage(
            int battleMode
        )
        {
            BattleMode = battleMode;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BattleMode = reader.ReadInt();
        }
    }
}