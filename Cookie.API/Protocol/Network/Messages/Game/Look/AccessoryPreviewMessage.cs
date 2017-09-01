using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Look
{
    public class AccessoryPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6517;

        public AccessoryPreviewMessage(EntityLook look)
        {
            Look = look;
        }

        public AccessoryPreviewMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public EntityLook Look { get; set; }

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