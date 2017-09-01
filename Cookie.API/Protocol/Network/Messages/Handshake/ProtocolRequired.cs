using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Handshake
{
    public class ProtocolRequired : NetworkMessage
    {
        public const ushort ProtocolId = 1;

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            RequiredVersion = requiredVersion;
            CurrentVersion = currentVersion;
        }

        public ProtocolRequired()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int RequiredVersion { get; set; }
        public int CurrentVersion { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequiredVersion);
            writer.WriteInt(CurrentVersion);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequiredVersion = reader.ReadInt();
            CurrentVersion = reader.ReadInt();
        }
    }
}