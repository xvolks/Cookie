using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5887;

        public GuildKickRequestMessage(ulong kickedId)
        {
            KickedId = kickedId;
        }

        public GuildKickRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong KickedId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarUhLong();
        }
    }
}