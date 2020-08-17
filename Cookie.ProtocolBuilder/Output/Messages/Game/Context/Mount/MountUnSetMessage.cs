namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountUnSetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5982;
        public override ushort MessageID => ProtocolId;

        public MountUnSetMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
