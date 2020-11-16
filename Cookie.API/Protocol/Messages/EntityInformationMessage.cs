using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EntityInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6771;

        public override ushort MessageID => ProtocolId;

        public EntityInformation Entity { get; set; }
        public EntityInformationMessage() { }

        public EntityInformationMessage( EntityInformation Entity ){
            this.Entity = Entity;
        }

        public override void Serialize(IDataWriter writer)
        {
            Entity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Entity = new EntityInformation();
            Entity.Deserialize(reader);
        }
    }
}
