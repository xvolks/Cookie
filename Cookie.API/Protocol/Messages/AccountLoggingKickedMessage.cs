using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccountLoggingKickedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6029;

        public override ushort MessageID => ProtocolId;

        public ushort Days { get; set; }
        public sbyte Hours { get; set; }
        public sbyte Minutes { get; set; }
        public AccountLoggingKickedMessage() { }

        public AccountLoggingKickedMessage( ushort Days, sbyte Hours, sbyte Minutes ){
            this.Days = Days;
            this.Hours = Hours;
            this.Minutes = Minutes;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Days);
            writer.WriteSByte(Hours);
            writer.WriteSByte(Minutes);
        }

        public override void Deserialize(IDataReader reader)
        {
            Days = reader.ReadVarUhShort();
            Hours = reader.ReadSByte();
            Minutes = reader.ReadSByte();
        }
    }
}
