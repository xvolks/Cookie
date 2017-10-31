namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicNoOperationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 176;
        public override ushort MessageID => ProtocolId;

        public BasicNoOperationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
