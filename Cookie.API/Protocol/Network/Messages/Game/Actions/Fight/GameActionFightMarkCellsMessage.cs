using Cookie.API.Protocol.Network.Types.Game.Actions.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5540;

        public GameActionFightMarkCellsMessage(GameActionMark mark)
        {
            Mark = mark;
        }

        public GameActionFightMarkCellsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GameActionMark Mark { get; set; }

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