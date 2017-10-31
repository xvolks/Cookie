namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Types.Game.Actions.Fight;
    using Utils.IO;

    public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5540;
        public override ushort MessageID => ProtocolId;
        public GameActionMark Mark { get; set; }

        public GameActionFightMarkCellsMessage(GameActionMark mark)
        {
            Mark = mark;
        }

        public GameActionFightMarkCellsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Mark.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Mark = new GameActionMark();
            Mark.Deserialize(reader);
        }

    }
}
