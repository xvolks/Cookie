namespace Cookie.API.Protocol.Network.Messages.Game.Guest
{
    using Utils.IO;

    public class GuestModeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6505;
        public override ushort MessageID => ProtocolId;
        public bool Active { get; set; }

        public GuestModeMessage(bool active)
        {
            Active = active;
        }

        public GuestModeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            Active = reader.ReadBoolean();
        }

    }
}
