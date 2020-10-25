using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
    {
        public new const uint ProtocolId = 6000;
        public override uint MessageID { get { return ProtocolId; } }

        public short ObjectGenericId = 0;

        public ExchangeCraftResultWithObjectIdMessage(): base()
        {
        }

        public ExchangeCraftResultWithObjectIdMessage(
            byte craftResult,
            short objectGenericId
        ): base(
            craftResult
        )
        {
            ObjectGenericId = objectGenericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(ObjectGenericId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectGenericId = reader.ReadVarShort();
        }
    }
}