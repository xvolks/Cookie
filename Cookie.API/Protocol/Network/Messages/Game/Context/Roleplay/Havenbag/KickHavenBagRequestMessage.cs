using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class KickHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6652;

        public KickHavenBagRequestMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public KickHavenBagRequestMessage()
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