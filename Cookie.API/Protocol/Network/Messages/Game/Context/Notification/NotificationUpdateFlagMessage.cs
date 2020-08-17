namespace Cookie.API.Protocol.Network.Messages.Game.Context.Notification
{
    using Utils.IO;

    public class NotificationUpdateFlagMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6090;
        public override ushort MessageID => ProtocolId;
        public ushort Index { get; set; }

        public NotificationUpdateFlagMessage(ushort index)
        {
            Index = index;
        }

        public NotificationUpdateFlagMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            Index = reader.ReadVarUhShort();
        }

    }
}
