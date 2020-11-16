using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
    {
        public new const ushort ProtocolId = 6176;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public GameActionFightDispellSpellMessage() { }

        public GameActionFightDispellSpellMessage( ushort SpellId ){
            this.SpellId = SpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUhShort();
        }
    }
}
