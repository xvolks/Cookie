using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
    {
        public new const uint ProtocolId = 6188;
        public override uint MessageID { get { return ProtocolId; } }

        public byte MagicPoolStatus = 0;

        public ExchangeCraftResultMagicWithObjectDescMessage(): base()
        {
        }

        public ExchangeCraftResultMagicWithObjectDescMessage(
            byte craftResult,
            ObjectItemNotInContainer objectInfo,
            byte magicPoolStatus
        ): base(
            craftResult,
            objectInfo
        )
        {
            MagicPoolStatus = magicPoolStatus;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(MagicPoolStatus);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MagicPoolStatus = reader.ReadByte();
        }
    }
}