using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6021;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Allow = false;

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
        {
        }

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(
            bool allow
        )
        {
            Allow = allow;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Allow);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Allow = reader.ReadBoolean();
        }
    }
}