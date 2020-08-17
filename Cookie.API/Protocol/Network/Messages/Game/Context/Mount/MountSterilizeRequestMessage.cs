namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountSterilizeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5962;
        public override ushort MessageID => ProtocolId;

        public MountSterilizeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
