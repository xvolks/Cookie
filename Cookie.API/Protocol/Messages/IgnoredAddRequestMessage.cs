using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IgnoredAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5673;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public bool Session { get; set; }
        public IgnoredAddRequestMessage() { }

        public IgnoredAddRequestMessage( string Name, bool Session ){
            this.Name = Name;
            this.Session = Session;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Session = reader.ReadBoolean();
        }
    }
}
