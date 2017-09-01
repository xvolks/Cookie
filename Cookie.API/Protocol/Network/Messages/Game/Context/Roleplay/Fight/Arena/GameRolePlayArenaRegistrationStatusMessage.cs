using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6284;

        public GameRolePlayArenaRegistrationStatusMessage(bool registered, byte step, int battleMode)
        {
            Registered = registered;
            Step = step;
            BattleMode = battleMode;
        }

        public GameRolePlayArenaRegistrationStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Registered { get; set; }
        public byte Step { get; set; }
        public int BattleMode { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Registered);
            writer.WriteByte(Step);
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(IDataReader reader)
        {
            Registered = reader.ReadBoolean();
            Step = reader.ReadByte();
            BattleMode = reader.ReadInt();
        }
    }
}