using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectorySettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5652;

        public JobCrafterDirectorySettingsMessage(List<JobCrafterDirectorySettings> craftersSettings)
        {
            CraftersSettings = craftersSettings;
        }

        public JobCrafterDirectorySettingsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<JobCrafterDirectorySettings> CraftersSettings { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) CraftersSettings.Count);
            for (var craftersSettingsIndex = 0; craftersSettingsIndex < CraftersSettings.Count; craftersSettingsIndex++)
            {
                var objectToSend = CraftersSettings[craftersSettingsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var craftersSettingsCount = reader.ReadUShort();
            CraftersSettings = new List<JobCrafterDirectorySettings>();
            for (var craftersSettingsIndex = 0; craftersSettingsIndex < craftersSettingsCount; craftersSettingsIndex++)
            {
                var objectToAdd = new JobCrafterDirectorySettings();
                objectToAdd.Deserialize(reader);
                CraftersSettings.Add(objectToAdd);
            }
        }
    }
}