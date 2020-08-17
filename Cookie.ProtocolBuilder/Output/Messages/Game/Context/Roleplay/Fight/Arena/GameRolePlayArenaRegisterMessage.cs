namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    using Utils.IO;

    public class GameRolePlayArenaRegisterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6280;
        public override ushort MessageID => ProtocolId;
        public int BattleMode { get; set; }

        public GameRolePlayArenaRegisterMessage(int battleMode)
        {
            BattleMode = battleMode;
        }

        public GameRolePlayArenaRegisterMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(IDataReader reader)
        {
            BattleMode = reader.ReadInt();
        }

    }
}
