using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5649;
        public override uint MessageID { get { return ProtocolId; } }

        public JobCrafterDirectorySettings Settings;

        public JobCrafterDirectoryDefineSettingsMessage()
        {
        }

        public JobCrafterDirectoryDefineSettingsMessage(
            JobCrafterDirectorySettings settings
        )
        {
            Settings = settings;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Settings.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Settings = new JobCrafterDirectorySettings();
            Settings.Deserialize(reader);
        }
    }
}