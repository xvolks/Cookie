using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5955;

        public GuildPaddockRemovedMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockRemovedMessage()
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