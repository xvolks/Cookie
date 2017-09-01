namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Context.Roleplay.Quest;
    using Types.Game.Look;
    using Utils.IO;

    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public new const ushort ProtocolId = 383;
        public override ushort TypeID => ProtocolId;
        public GameRolePlayNpcQuestFlag QuestFlag { get; set; }

        public GameRolePlayNpcWithQuestInformations(GameRolePlayNpcQuestFlag questFlag)
        {
            QuestFlag = questFlag;
        }

        public GameRolePlayNpcWithQuestInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            QuestFlag.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            QuestFlag = new GameRolePlayNpcQuestFlag();
            QuestFlag.Deserialize(reader);
        }

    }
}
