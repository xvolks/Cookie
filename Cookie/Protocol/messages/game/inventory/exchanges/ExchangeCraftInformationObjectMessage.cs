using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
    {
        public new const uint ProtocolId = 5794;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public ExchangeCraftInformationObjectMessage(): base()
        {
        }

        public ExchangeCraftInformationObjectMessage(
            byte craftResult,
            short objectGenericId,
            long playerId
        ): base(
            craftResult,
            objectGenericId
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
        }
    }
}