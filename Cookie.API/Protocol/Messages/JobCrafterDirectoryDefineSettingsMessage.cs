using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5649;

        public override ushort MessageID => ProtocolId;

        public JobCrafterDirectorySettings Settings { get; set; }
        public JobCrafterDirectoryDefineSettingsMessage() { }

        public JobCrafterDirectoryDefineSettingsMessage( JobCrafterDirectorySettings Settings ){
            this.Settings = Settings;
        }

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
