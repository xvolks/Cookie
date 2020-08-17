using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class HavenBagPermissionsUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6714;

        public HavenBagPermissionsUpdateRequestMessage(int permissions)
        {
            Permissions = permissions;
        }

        public HavenBagPermissionsUpdateRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int Permissions { get; set; }

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