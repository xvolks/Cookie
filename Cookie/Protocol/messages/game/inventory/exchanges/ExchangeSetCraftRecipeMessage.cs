using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeSetCraftRecipeMessage : NetworkMessage
    {
        public const uint ProtocolId = 6389;
        public override uint MessageID { get { return ProtocolId; } }

        public short ObjectGID = 0;

        public ExchangeSetCraftRecipeMessage()
        {
        }

        public ExchangeSetCraftRecipeMessage(
            short objectGID
        )
        {
            ObjectGID = objectGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ObjectGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectGID = reader.ReadVarShort();
        }
    }
}