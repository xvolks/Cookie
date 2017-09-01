using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Notification
{
    public class NotificationUpdateFlagMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6090;

        public NotificationUpdateFlagMessage(ushort index)
        {
            Index = index;
        }

        public NotificationUpdateFlagMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort Index { get; set; }

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