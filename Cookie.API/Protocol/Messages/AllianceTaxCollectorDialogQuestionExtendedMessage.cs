using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        public new const ushort ProtocolId = 6445;

        public override ushort MessageID => ProtocolId;

        public BasicNamedAllianceInformations Alliance { get; set; }
        public AllianceTaxCollectorDialogQuestionExtendedMessage() { }

        public AllianceTaxCollectorDialogQuestionExtendedMessage( BasicNamedAllianceInformations Alliance ){
            this.Alliance = Alliance;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicNamedAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}
