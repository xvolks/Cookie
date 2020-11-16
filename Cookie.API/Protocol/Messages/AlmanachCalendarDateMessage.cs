using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AlmanachCalendarDateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6341;

        public override ushort MessageID => ProtocolId;

        public int Date { get; set; }
        public AlmanachCalendarDateMessage() { }

        public AlmanachCalendarDateMessage( int Date ){
            this.Date = Date;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            Date = reader.ReadInt();
        }
    }
}
