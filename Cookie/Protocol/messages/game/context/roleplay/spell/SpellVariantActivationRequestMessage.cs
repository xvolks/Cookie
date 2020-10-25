using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SpellVariantActivationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6707;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;

        public SpellVariantActivationRequestMessage()
        {
        }

        public SpellVariantActivationRequestMessage(
            short spellId
        )
        {
            SpellId = spellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadVarShort();
        }
    }
}