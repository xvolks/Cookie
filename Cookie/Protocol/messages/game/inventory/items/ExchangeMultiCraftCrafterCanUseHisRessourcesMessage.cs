using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6020;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Allowed = false;

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
        {
        }

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(
            bool allowed
        )
        {
            Allowed = allowed;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Allowed);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Allowed = reader.ReadBoolean();
        }
    }
}