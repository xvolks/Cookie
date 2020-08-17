namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Death
{
    using Utils.IO;

    public class WarnOnPermaDeathMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6512;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public WarnOnPermaDeathMessage(bool enable)
        {
            Enable = enable;
        }

        public WarnOnPermaDeathMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }

    }
}
