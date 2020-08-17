namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountHarnessDissociateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6696;
        public override ushort MessageID => ProtocolId;

        public MountHarnessDissociateRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
