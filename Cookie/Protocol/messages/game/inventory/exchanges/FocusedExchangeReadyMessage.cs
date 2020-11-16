using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FocusedExchangeReadyMessage : ExchangeReadyMessage
    {
        public new const uint ProtocolId = 6701;
        public override uint MessageID { get { return ProtocolId; } }

        public int FocusActionId = 0;

        public FocusedExchangeReadyMessage(): base()
        {
        }

        public FocusedExchangeReadyMessage(
            bool ready,
            short step,
            int focusActionId
        ): base(
            ready,
            step
        )
        {
            FocusActionId = focusActionId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(FocusActionId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FocusActionId = reader.ReadVarInt();
        }
    }
}