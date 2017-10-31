namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Types.Game.Mount;
    using Utils.IO;

    public class MountSetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5968;
        public override ushort MessageID => ProtocolId;
        public MountClientData MountData { get; set; }

        public MountSetMessage(MountClientData mountData)
        {
            MountData = mountData;
        }

        public MountSetMessage() { }

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
