using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HavenBagPermissionsUpdateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6714;
        public override uint MessageID { get { return ProtocolId; } }

        public int Permissions = 0;

        public HavenBagPermissionsUpdateRequestMessage()
        {
        }

        public HavenBagPermissionsUpdateRequestMessage(
            int permissions
        )
        {
            Permissions = permissions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Permissions);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Permissions = reader.ReadInt();
        }
    }
}