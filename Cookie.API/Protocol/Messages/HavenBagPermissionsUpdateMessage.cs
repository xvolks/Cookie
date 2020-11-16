using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HavenBagPermissionsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6713;

        public override ushort MessageID => ProtocolId;

        public int Permissions { get; set; }
        public HavenBagPermissionsUpdateMessage() { }

        public HavenBagPermissionsUpdateMessage( int Permissions ){
            this.Permissions = Permissions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Permissions);
        }

        public override void Deserialize(IDataReader reader)
        {
            Permissions = reader.ReadInt();
        }
    }
}
