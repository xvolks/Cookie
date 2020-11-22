using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 6538;
        public override uint MessageID { get { return ProtocolId; } }

        public StartupActionAddObject NewAction;

        public StartupActionAddMessage()
        {
        }

        public StartupActionAddMessage(
            StartupActionAddObject newAction
        )
        {
            NewAction = newAction;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            NewAction.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NewAction = new StartupActionAddObject();
            NewAction.Deserialize(reader);
        }
    }
}