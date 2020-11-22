using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StartupActionAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6538;

        public override ushort MessageID => ProtocolId;

        public StartupActionAddObject NewAction { get; set; }
        public StartupActionAddMessage() { }

        public StartupActionAddMessage( StartupActionAddObject NewAction ){
            this.NewAction = NewAction;
        }

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
