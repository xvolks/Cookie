using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Interactive.Skill;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobDescription : NetworkType
    {
        public const ushort ProtocolId = 101;

        public JobDescription(byte jobId, List<SkillActionDescription> skills)
        {
            JobId = jobId;
            Skills = skills;
        }

        public JobDescription()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte JobId { get; set; }
        public List<SkillActionDescription> Skills { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteShort((short) Skills.Count);
            for (var skillsIndex = 0; skillsIndex < Skills.Count; skillsIndex++)
            {
                var objectToSend = Skills[skillsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            var skillsCount = reader.ReadUShort();
            Skills = new List<SkillActionDescription>();
            for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Skills.Add(objectToAdd);
            }
        }
    }
}