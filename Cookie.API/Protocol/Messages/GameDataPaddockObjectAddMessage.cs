using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameDataPaddockObjectAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5990;

        public override ushort MessageID => ProtocolId;

        public PaddockItem PaddockItemDescription { get; set; }
        public GameDataPaddockObjectAddMessage() { }

        public GameDataPaddockObjectAddMessage( PaddockItem PaddockItemDescription ){
            this.PaddockItemDescription = PaddockItemDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
            PaddockItemDescription.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockItemDescription = new PaddockItem();
            PaddockItemDescription.Deserialize(reader);
        }
    }
}
