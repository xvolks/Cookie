using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5540;

        public override ushort MessageID => ProtocolId;

        public GameActionMark Mark { get; set; }
        public GameActionFightMarkCellsMessage() { }

        public GameActionFightMarkCellsMessage( GameActionMark Mark ){
            this.Mark = Mark;
        }

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
