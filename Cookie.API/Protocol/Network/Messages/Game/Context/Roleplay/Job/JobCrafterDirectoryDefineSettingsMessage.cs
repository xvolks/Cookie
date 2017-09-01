using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5649;

        public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
        {
            Settings = settings;
        }

        public JobCrafterDirectoryDefineSettingsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public JobCrafterDirectorySettings Settings { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Settings.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Settings = new JobCrafterDirectorySettings();
            Settings.Deserialize(reader);
        }
    }
}