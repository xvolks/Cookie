namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Types.Connection;
    using Utils.IO;

    public class ServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 50;
        public override ushort MessageID => ProtocolId;
        public GameServerInformations Server { get; set; }

        public ServerStatusUpdateMessage(GameServerInformations server)
        {
            Server = server;
        }

        public ServerStatusUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Server.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Server = new GameServerInformations();
            Server.Deserialize(reader);
        }

    }
}
