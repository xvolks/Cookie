using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GoldAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6030;

        public override ushort MessageID => ProtocolId;

        public GoldItem Gold { get; set; }
        public GoldAddedMessage() { }

        public GoldAddedMessage( GoldItem Gold ){
            this.Gold = Gold;
        }

        public override void Serialize(IDataWriter writer)
        {
            Gold.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Gold = new GoldItem();
            Gold.Deserialize(reader);
        }
    }
}
