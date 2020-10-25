using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectorySettingsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5652;
        public override uint MessageID { get { return ProtocolId; } }

        public List<JobCrafterDirectorySettings> CraftersSettings;

        public JobCrafterDirectorySettingsMessage()
        {
        }

        public JobCrafterDirectorySettingsMessage(
            List<JobCrafterDirectorySettings> craftersSettings
        )
        {
            CraftersSettings = craftersSettings;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)CraftersSettings.Count());
            foreach (var current in CraftersSettings)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCraftersSettings = reader.ReadShort();
            CraftersSettings = new List<JobCrafterDirectorySettings>();
            for (short i = 0; i < countCraftersSettings; i++)
            {
                JobCrafterDirectorySettings type = new JobCrafterDirectorySettings();
                type.Deserialize(reader);
                CraftersSettings.Add(type);
            }
        }
    }
}