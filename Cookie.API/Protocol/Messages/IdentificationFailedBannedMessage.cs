using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationFailedBannedMessage : IdentificationFailedMessage
    {
        public new const ushort ProtocolId = 6174;

        public override ushort MessageID => ProtocolId;

        public double BanEndDate { get; set; }
        public IdentificationFailedBannedMessage() { }

        public IdentificationFailedBannedMessage( double BanEndDate ){
            this.BanEndDate = BanEndDate;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(BanEndDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BanEndDate = reader.ReadDouble();
        }
    }
}
