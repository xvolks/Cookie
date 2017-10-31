namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    using Utils.IO;

    public class TeleportHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6647;
        public override ushort MessageID => ProtocolId;
        public ulong GuestId { get; set; }

        public TeleportHavenBagRequestMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public TeleportHavenBagRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestId = reader.ReadVarUhLong();
        }

    }
}
