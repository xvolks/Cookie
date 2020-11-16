using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HavenBagPermissionsUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6713;
        public override uint MessageID { get { return ProtocolId; } }

        public int Permissions = 0;

        public HavenBagPermissionsUpdateMessage()
        {
        }

        public HavenBagPermissionsUpdateMessage(
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