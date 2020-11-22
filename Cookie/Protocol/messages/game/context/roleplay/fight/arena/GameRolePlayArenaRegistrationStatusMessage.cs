using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6284;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Registered = false;
        public byte Step = 0;
        public int BattleMode = 3;

        public GameRolePlayArenaRegistrationStatusMessage()
        {
        }

        public GameRolePlayArenaRegistrationStatusMessage(
            bool registered,
            byte step,
            int battleMode
        )
        {
            Registered = registered;
            Step = step;
            BattleMode = battleMode;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Registered);
            writer.WriteByte(Step);
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Registered = reader.ReadBoolean();
            Step = reader.ReadByte();
            BattleMode = reader.ReadInt();
        }
    }
}