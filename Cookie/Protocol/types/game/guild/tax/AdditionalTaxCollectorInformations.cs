using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AdditionalTaxCollectorInformations : NetworkType
    {
        public const short ProtocolId = 165;
        public override short TypeId { get { return ProtocolId; } }

        public string CollectorCallerName;
        public int Date = 0;

        public AdditionalTaxCollectorInformations()
        {
        }

        public AdditionalTaxCollectorInformations(
            string collectorCallerName,
            int date
        )
        {
            CollectorCallerName = collectorCallerName;
            Date = date;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(CollectorCallerName);
            writer.WriteInt(Date);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CollectorCallerName = reader.ReadUTF();
            Date = reader.ReadInt();
        }
    }
}