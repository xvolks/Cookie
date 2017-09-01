namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildLeftMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5562;
        public override ushort MessageID => ProtocolId;

        public GuildLeftMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
