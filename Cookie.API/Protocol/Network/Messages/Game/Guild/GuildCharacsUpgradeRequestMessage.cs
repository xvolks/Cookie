namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildCharacsUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5706;
        public override ushort MessageID => ProtocolId;
        public byte CharaTypeTarget { get; set; }

        public GuildCharacsUpgradeRequestMessage(byte charaTypeTarget)
        {
            CharaTypeTarget = charaTypeTarget;
        }

        public GuildCharacsUpgradeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(CharaTypeTarget);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharaTypeTarget = reader.ReadByte();
        }

    }
}
