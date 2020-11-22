using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameEntityDispositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5693;

        public override ushort MessageID => ProtocolId;

        public IdentifiedEntityDispositionInformations Disposition { get; set; }
        public GameEntityDispositionMessage() { }

        public GameEntityDispositionMessage( IdentifiedEntityDispositionInformations Disposition ){
            this.Disposition = Disposition;
        }

        public override void Serialize(IDataWriter writer)
        {
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Disposition = new IdentifiedEntityDispositionInformations();
            Disposition.Deserialize(reader);
        }
    }
}
