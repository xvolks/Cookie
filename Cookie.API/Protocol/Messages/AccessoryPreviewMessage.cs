using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccessoryPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6517;

        public override ushort MessageID => ProtocolId;

        public EntityLook Look { get; set; }
        public AccessoryPreviewMessage() { }

        public AccessoryPreviewMessage( EntityLook Look ){
            this.Look = Look;
        }

        public override void Serialize(IDataWriter writer)
        {
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}
