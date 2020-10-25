using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolPartyLostMessage : NetworkMessage
    {
        public const uint ProtocolId = 6580;
        public override uint MessageID { get { return ProtocolId; } }

        public short IdolId = 0;

        public IdolPartyLostMessage()
        {
        }

        public IdolPartyLostMessage(
            short idolId
        )
        {
            IdolId = idolId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(IdolId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IdolId = reader.ReadVarShort();
        }
    }
}