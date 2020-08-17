using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildPaddockTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5957;

        public GuildPaddockTeleportRequestMessage(int paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockTeleportRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int PaddockId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PaddockId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadInt();
        }
    }
}