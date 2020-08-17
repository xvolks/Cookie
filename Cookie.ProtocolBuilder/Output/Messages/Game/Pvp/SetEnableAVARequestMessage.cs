namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    using Utils.IO;

    public class SetEnableAVARequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6443;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public SetEnableAVARequestMessage(bool enable)
        {
            Enable = enable;
        }

        public SetEnableAVARequestMessage() { }

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
