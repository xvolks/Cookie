using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildPaddockTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5957;

        public GuildPaddockTeleportRequestMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockTeleportRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double PaddockId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
        }
    }
}