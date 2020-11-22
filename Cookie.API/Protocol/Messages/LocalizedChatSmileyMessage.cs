using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LocalizedChatSmileyMessage : ChatSmileyMessage
    {
        public new const ushort ProtocolId = 6185;

        public override ushort MessageID => ProtocolId;

        public ushort CellId { get; set; }
        public LocalizedChatSmileyMessage() { }

        public LocalizedChatSmileyMessage( ushort CellId ){
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CellId = reader.ReadVarUhShort();
        }
    }
}
