namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildCreationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5920;
        public override ushort MessageID => ProtocolId;

        public GuildCreationStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
