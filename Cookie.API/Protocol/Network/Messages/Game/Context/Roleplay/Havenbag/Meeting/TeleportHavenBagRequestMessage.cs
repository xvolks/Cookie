using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class TeleportHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6647;

        public TeleportHavenBagRequestMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public TeleportHavenBagRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong GuestId { get; set; }

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