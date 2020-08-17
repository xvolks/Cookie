namespace Cookie.API.Protocol.Network.Messages.Connection.Register
{
    using Utils.IO;

    public class NicknameRegistrationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5640;
        public override ushort MessageID => ProtocolId;

        public NicknameRegistrationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
