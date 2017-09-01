using Cookie.API.Protocol.Network.Types.Game.Startup;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6538;

        public StartupActionAddMessage(StartupActionAddObject newAction)
        {
            NewAction = newAction;
        }

        public StartupActionAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public StartupActionAddObject NewAction { get; set; }

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