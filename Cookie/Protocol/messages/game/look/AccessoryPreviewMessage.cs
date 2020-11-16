using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AccessoryPreviewMessage : NetworkMessage
    {
        public const uint ProtocolId = 6517;
        public override uint MessageID { get { return ProtocolId; } }

        public EntityLook Look;

        public AccessoryPreviewMessage()
        {
        }

        public AccessoryPreviewMessage(
            EntityLook look
        )
        {
            Look = look;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Look.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}