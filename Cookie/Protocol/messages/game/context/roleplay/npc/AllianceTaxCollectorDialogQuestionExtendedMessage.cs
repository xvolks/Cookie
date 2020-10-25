using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
    {
        public new const uint ProtocolId = 6445;
        public override uint MessageID { get { return ProtocolId; } }

        public BasicNamedAllianceInformations Alliance;

        public AllianceTaxCollectorDialogQuestionExtendedMessage(): base()
        {
        }

        public AllianceTaxCollectorDialogQuestionExtendedMessage(
            BasicGuildInformations guildInfo,
            short maxPods,
            short prospecting,
            short wisdom,
            byte taxCollectorsCount,
            int taxCollectorAttack,
            long kamas,
            long experience,
            int pods,
            long itemsValue,
            BasicNamedAllianceInformations alliance
        ): base(
            guildInfo,
            maxPods,
            prospecting,
            wisdom,
            taxCollectorsCount,
            taxCollectorAttack,
            kamas,
            experience,
            pods,
            itemsValue
        )
        {
            Alliance = alliance;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicNamedAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}