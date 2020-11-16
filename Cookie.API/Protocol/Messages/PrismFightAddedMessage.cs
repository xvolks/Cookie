using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6452;

        public override ushort MessageID => ProtocolId;

        public PrismFightersInformation Fight { get; set; }
        public PrismFightAddedMessage() { }

        public PrismFightAddedMessage( PrismFightersInformation Fight ){
            this.Fight = Fight;
        }

        public override void Serialize(IDataWriter writer)
        {
            Fight.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Fight = new PrismFightersInformation();
            Fight.Deserialize(reader);
        }
    }
}
