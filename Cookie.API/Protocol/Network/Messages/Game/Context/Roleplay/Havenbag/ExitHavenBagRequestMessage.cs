namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class ExitHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6631;
        public override ushort MessageID => ProtocolId;

        public ExitHavenBagRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
