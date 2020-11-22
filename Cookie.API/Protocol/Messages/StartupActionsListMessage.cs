using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StartupActionsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1301;

        public override ushort MessageID => ProtocolId;

        public List<StartupActionAddObject> Actions { get; set; }
        public StartupActionsListMessage() { }

        public StartupActionsListMessage( List<StartupActionAddObject> Actions ){
            this.Actions = Actions;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Actions.Count);
			foreach (var x in Actions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ActionsCount = reader.ReadShort();
            Actions = new List<StartupActionAddObject>();
            for (var i = 0; i < ActionsCount; i++)
            {
                var objectToAdd = new StartupActionAddObject();
                objectToAdd.Deserialize(reader);
                Actions.Add(objectToAdd);
            }
        }
    }
}
