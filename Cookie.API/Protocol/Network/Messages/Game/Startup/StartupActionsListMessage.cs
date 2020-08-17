using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Startup;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Startup
{
    public class StartupActionsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1301;

        public StartupActionsListMessage(List<StartupActionAddObject> actions)
        {
            Actions = actions;
        }

        public StartupActionsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<StartupActionAddObject> Actions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Actions.Count);
            for (var actionsIndex = 0; actionsIndex < Actions.Count; actionsIndex++)
            {
                var objectToSend = Actions[actionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var actionsCount = reader.ReadUShort();
            Actions = new List<StartupActionAddObject>();
            for (var actionsIndex = 0; actionsIndex < actionsCount; actionsIndex++)
            {
                var objectToAdd = new StartupActionAddObject();
                objectToAdd.Deserialize(reader);
                Actions.Add(objectToAdd);
            }
        }
    }
}