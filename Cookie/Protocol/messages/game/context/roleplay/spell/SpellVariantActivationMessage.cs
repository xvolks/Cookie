using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SpellVariantActivationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6705;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;
        public bool Result = false;

        public SpellVariantActivationMessage()
        {
        }

        public SpellVariantActivationMessage(
            short spellId,
            bool result
        )
        {
            SpellId = spellId;
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SpellId);
            writer.WriteBoolean(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadVarShort();
            Result = reader.ReadBoolean();
        }
    }
}