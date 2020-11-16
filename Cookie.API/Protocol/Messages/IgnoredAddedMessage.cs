using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IgnoredAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5678;

        public override ushort MessageID => ProtocolId;

        public IgnoredInformations IgnoreAdded { get; set; }
        public bool Session { get; set; }
        public IgnoredAddedMessage() { }

        public IgnoredAddedMessage( IgnoredInformations IgnoreAdded, bool Session ){
            this.IgnoreAdded = IgnoreAdded;
            this.Session = Session;
        }

        public override void Serialize(IDataWriter writer)
        {
            IgnoreAdded.Serialize(writer);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            IgnoreAdded = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            IgnoreAdded.Deserialize(reader);
            Session = reader.ReadBoolean();
        }
    }
}
