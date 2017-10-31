namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    using Utils.IO;

    public class HavenBagPermissionsUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6714;
        public override ushort MessageID => ProtocolId;
        public int Permissions { get; set; }

        public HavenBagPermissionsUpdateRequestMessage(int permissions)
        {
            Permissions = permissions;
        }

        public HavenBagPermissionsUpdateRequestMessage() { }

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
