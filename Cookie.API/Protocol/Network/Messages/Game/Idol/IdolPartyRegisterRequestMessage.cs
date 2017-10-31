namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    using Utils.IO;

    public class IdolPartyRegisterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6582;
        public override ushort MessageID => ProtocolId;
        public bool Register { get; set; }

        public IdolPartyRegisterRequestMessage(bool register)
        {
            Register = register;
        }

        public IdolPartyRegisterRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Register);
        }

        public override void Deserialize(IDataReader reader)
        {
            Register = reader.ReadBoolean();
        }

    }
}
