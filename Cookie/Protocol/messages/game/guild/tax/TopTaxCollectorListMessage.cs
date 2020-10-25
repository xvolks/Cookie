using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const uint ProtocolId = 6565;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsDungeon = false;

        public TopTaxCollectorListMessage(): base()
        {
        }

        public TopTaxCollectorListMessage(
            List<TaxCollectorInformations> informations,
            bool isDungeon
        ): base(
            informations
        )
        {
            IsDungeon = isDungeon;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(IsDungeon);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            IsDungeon = reader.ReadBoolean();
        }
    }
}