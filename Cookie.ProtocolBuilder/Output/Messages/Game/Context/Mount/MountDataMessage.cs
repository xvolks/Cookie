namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Types.Game.Mount;
    using Utils.IO;

    public class MountDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5973;
        public override ushort MessageID => ProtocolId;
        public MountClientData MountData { get; set; }

        public MountDataMessage(MountClientData mountData)
        {
            MountData = mountData;
        }

        public MountDataMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            MountData.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountData = new MountClientData();
            MountData.Deserialize(reader);
        }

    }
}
