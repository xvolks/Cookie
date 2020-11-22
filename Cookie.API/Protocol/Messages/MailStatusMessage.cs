using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MailStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6275;

        public override ushort MessageID => ProtocolId;

        public ushort Unread { get; set; }
        public ushort Total { get; set; }
        public MailStatusMessage() { }

        public MailStatusMessage( ushort Unread, ushort Total ){
            this.Unread = Unread;
            this.Total = Total;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Unread);
            writer.WriteVarUhShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Unread = reader.ReadVarUhShort();
            Total = reader.ReadVarUhShort();
        }
    }
}
