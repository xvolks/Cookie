using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5540;
        public override uint MessageID { get { return ProtocolId; } }

        public GameActionMark Mark;

        public GameActionFightMarkCellsMessage(): base()
        {
        }

        public GameActionFightMarkCellsMessage(
            short actionId,
            double sourceId,
            GameActionMark mark
        ): base(
            actionId,
            sourceId
        )
        {
            Mark = mark;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Mark.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Mark = new GameActionMark();
            Mark.Deserialize(reader);
        }
    }
}