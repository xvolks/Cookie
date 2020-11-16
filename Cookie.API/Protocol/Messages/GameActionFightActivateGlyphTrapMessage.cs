using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6545;

        public override ushort MessageID => ProtocolId;

        public short MarkId { get; set; }
        public bool Active { get; set; }
        public GameActionFightActivateGlyphTrapMessage() { }

        public GameActionFightActivateGlyphTrapMessage( short MarkId, bool Active ){
            this.MarkId = MarkId;
            this.Active = Active;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            Active = reader.ReadBoolean();
        }
    }
}
