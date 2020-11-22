using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6020;

        public override ushort MessageID => ProtocolId;

        public bool Allowed { get; set; }
        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage() { }

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage( bool Allowed ){
            this.Allowed = Allowed;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allowed);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allowed = reader.ReadBoolean();
        }
    }
}
