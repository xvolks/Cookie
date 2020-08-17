namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceCreationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6394;
        public override ushort MessageID => ProtocolId;

        public AllianceCreationStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
