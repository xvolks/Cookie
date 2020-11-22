using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PortalDialogCreationMessage : NpcDialogCreationMessage
    {
        public new const ushort ProtocolId = 6737;

        public override ushort MessageID => ProtocolId;

        public int Type { get; set; }
        public PortalDialogCreationMessage() { }

        public PortalDialogCreationMessage( int Type ){
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Type = reader.ReadInt();
        }
    }
}
