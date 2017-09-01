namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5955;
        public override ushort MessageID => ProtocolId;
        public int PaddockId { get; set; }

        public GuildPaddockRemovedMessage(int paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockRemovedMessage() { }

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
