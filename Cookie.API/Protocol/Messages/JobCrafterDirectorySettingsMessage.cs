using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectorySettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5652;

        public override ushort MessageID => ProtocolId;

        public List<JobCrafterDirectorySettings> CraftersSettings { get; set; }
        public JobCrafterDirectorySettingsMessage() { }

        public JobCrafterDirectorySettingsMessage( List<JobCrafterDirectorySettings> CraftersSettings ){
            this.CraftersSettings = CraftersSettings;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)CraftersSettings.Count);
			foreach (var x in CraftersSettings)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CraftersSettingsCount = reader.ReadShort();
            CraftersSettings = new List<JobCrafterDirectorySettings>();
            for (var i = 0; i < CraftersSettingsCount; i++)
            {
                var objectToAdd = new JobCrafterDirectorySettings();
                objectToAdd.Deserialize(reader);
                CraftersSettings.Add(objectToAdd);
            }
        }
    }
}
