namespace Cookie.API.Protocol.Network.Messages.Game.Look
{
    using Types.Game.Look;
    using Utils.IO;

    public class AccessoryPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6517;
        public override ushort MessageID => ProtocolId;
        public EntityLook Look { get; set; }

        public AccessoryPreviewMessage(EntityLook look)
        {
            Look = look;
        }

        public AccessoryPreviewMessage() { }

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
