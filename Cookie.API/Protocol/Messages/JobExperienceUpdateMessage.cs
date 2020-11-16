using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5654;

        public override ushort MessageID => ProtocolId;

        public JobExperience ExperiencesUpdate { get; set; }
        public JobExperienceUpdateMessage() { }

        public JobExperienceUpdateMessage( JobExperience ExperiencesUpdate ){
            this.ExperiencesUpdate = ExperiencesUpdate;
        }

        public override void Serialize(IDataWriter writer)
        {
            ExperiencesUpdate.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencesUpdate = new JobExperience();
            ExperiencesUpdate.Deserialize(reader);
        }
    }
}
