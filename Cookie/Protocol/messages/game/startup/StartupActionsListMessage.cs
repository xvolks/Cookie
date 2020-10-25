using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 1301;
        public override uint MessageID { get { return ProtocolId; } }

        public List<StartupActionAddObject> Actions;

        public StartupActionsListMessage()
        {
        }

        public StartupActionsListMessage(
            List<StartupActionAddObject> actions
        )
        {
            Actions = actions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Actions.Count());
            foreach (var current in Actions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countActions = reader.ReadShort();
            Actions = new List<StartupActionAddObject>();
            for (short i = 0; i < countActions; i++)
            {
                StartupActionAddObject type = new StartupActionAddObject();
                type.Deserialize(reader);
                Actions.Add(type);
            }
        }
    }
}