using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5955;

        public GuildPaddockRemovedMessage(int paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockRemovedMessage()
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