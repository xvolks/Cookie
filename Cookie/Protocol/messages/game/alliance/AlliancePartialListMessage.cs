using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AlliancePartialListMessage : AllianceListMessage
    {
        public new const uint ProtocolId = 6427;
        public override uint MessageID { get { return ProtocolId; } }

        public AlliancePartialListMessage(): base()
        {
        }

        public AlliancePartialListMessage(
            List<AllianceFactSheetInformations> alliances
        ): base(
            alliances
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}