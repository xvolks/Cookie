namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    using Types.Game.Startup;
    using Utils.IO;

    public class StartupActionAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6538;
        public override ushort MessageID => ProtocolId;
        public StartupActionAddObject NewAction { get; set; }

        public StartupActionAddMessage(StartupActionAddObject newAction)
        {
            NewAction = newAction;
        }

        public StartupActionAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            NewAction.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewAction = new StartupActionAddObject();
            NewAction.Deserialize(reader);
        }

    }
}
