using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5570;

        public override ushort MessageID => ProtocolId;

        public short MarkId { get; set; }
        public GameActionFightUnmarkCellsMessage() { }

        public GameActionFightUnmarkCellsMessage( short MarkId ){
            this.MarkId = MarkId;
        }

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
