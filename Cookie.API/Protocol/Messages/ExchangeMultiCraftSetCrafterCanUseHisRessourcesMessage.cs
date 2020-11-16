using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6021;

        public override ushort MessageID => ProtocolId;

        public bool Allow { get; set; }
        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage() { }

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage( bool Allow ){
            this.Allow = Allow;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allow);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allow = reader.ReadBoolean();
        }
    }
}
