using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ShortcutSmiley : Shortcut
    {
        public new const ushort ProtocolId = 388;

        public override ushort TypeID => ProtocolId;

        public ushort SmileyId { get; set; }
        public ShortcutSmiley() { }

        public ShortcutSmiley( ushort SmileyId ){
            this.SmileyId = SmileyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SmileyId = reader.ReadVarUhShort();
        }
    }
}
