using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AdditionalTaxCollectorInformations : NetworkType
    {
        public const ushort ProtocolId = 165;

        public override ushort TypeID => ProtocolId;

        public string CollectorCallerName { get; set; }
        public int Date { get; set; }
        public AdditionalTaxCollectorInformations() { }

        public AdditionalTaxCollectorInformations( string CollectorCallerName, int Date ){
            this.CollectorCallerName = CollectorCallerName;
            this.Date = Date;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(CollectorCallerName);
            writer.WriteInt(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorCallerName = reader.ReadUTF();
            Date = reader.ReadInt();
        }
    }
}
