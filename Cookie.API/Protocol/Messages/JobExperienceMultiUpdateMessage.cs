using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobExperienceMultiUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5809;

        public override ushort MessageID => ProtocolId;

        public List<JobExperience> ExperiencesUpdate { get; set; }
        public JobExperienceMultiUpdateMessage() { }

        public JobExperienceMultiUpdateMessage( List<JobExperience> ExperiencesUpdate ){
            this.ExperiencesUpdate = ExperiencesUpdate;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ExperiencesUpdate.Count);
			foreach (var x in ExperiencesUpdate)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ExperiencesUpdateCount = reader.ReadShort();
            ExperiencesUpdate = new List<JobExperience>();
            for (var i = 0; i < ExperiencesUpdateCount; i++)
            {
                var objectToAdd = new JobExperience();
                objectToAdd.Deserialize(reader);
                ExperiencesUpdate.Add(objectToAdd);
            }
        }
    }
}
