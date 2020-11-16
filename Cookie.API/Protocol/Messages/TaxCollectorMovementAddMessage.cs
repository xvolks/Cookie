using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorMovementAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5917;

        public override ushort MessageID => ProtocolId;

        public TaxCollectorInformations Informations { get; set; }
        public TaxCollectorMovementAddMessage() { }

        public TaxCollectorMovementAddMessage( TaxCollectorInformations Informations ){
            this.Informations = Informations;
        }

        public override void Serialize(IDataWriter writer)
        {
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Informations.Deserialize(reader);
        }
    }
}
