namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    using Utils.IO;

    public class SetEnablePVPRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1810;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public SetEnablePVPRequestMessage(bool enable)
        {
            Enable = enable;
        }

        public SetEnablePVPRequestMessage() { }

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
