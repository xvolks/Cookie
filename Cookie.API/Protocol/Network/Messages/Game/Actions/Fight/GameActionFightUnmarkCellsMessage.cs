namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5570;
        public override ushort MessageID => ProtocolId;
        public short MarkId { get; set; }

        public GameActionFightUnmarkCellsMessage(short markId)
        {
            MarkId = markId;
        }

        public GameActionFightUnmarkCellsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
        }

    }
}
