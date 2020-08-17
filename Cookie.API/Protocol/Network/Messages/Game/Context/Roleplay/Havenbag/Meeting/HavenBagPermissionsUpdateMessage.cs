using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    public class HavenBagPermissionsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6713;

        public HavenBagPermissionsUpdateMessage(int permissions)
        {
            Permissions = permissions;
        }

        public HavenBagPermissionsUpdateMessage()
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