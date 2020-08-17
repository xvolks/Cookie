namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using Utils.IO;

    public class DareCreatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6668;
        public override ushort MessageID => ProtocolId;
        public DareInformations DareInfos { get; set; }
        public bool NeedNotifications { get; set; }

        public DareCreatedMessage(DareInformations dareInfos, bool needNotifications)
        {
            DareInfos = dareInfos;
            NeedNotifications = needNotifications;
        }

        public DareCreatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            DareInfos.Serialize(writer);
            writer.WriteBoolean(NeedNotifications);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareInfos = new DareInformations();
            DareInfos.Deserialize(reader);
            NeedNotifications = reader.ReadBoolean();
        }

    }
}
