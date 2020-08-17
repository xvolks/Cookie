namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountReleaseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5980;
        public override ushort MessageID => ProtocolId;

        public MountReleaseRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
