namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class IgnoredGetListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5676;
        public override ushort MessageID => ProtocolId;

        public IgnoredGetListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
