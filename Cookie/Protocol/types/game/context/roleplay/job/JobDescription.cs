using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class JobDescription : NetworkType
    {
        public const short ProtocolId = 101;
        public override short TypeId { get { return ProtocolId; } }

        public byte JobId = 0;
        public List<SkillActionDescription> Skills;

        public JobDescription()
        {
        }

        public JobDescription(
            byte jobId,
            List<SkillActionDescription> skills
        )
        {
            JobId = jobId;
            Skills = skills;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteShort((short)Skills.Count());
            foreach (var current in Skills)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            var countSkills = reader.ReadShort();
            Skills = new List<SkillActionDescription>();
            for (short i = 0; i < countSkills; i++)
            {
                var skillstypeId = reader.ReadUShort();
                SkillActionDescription type = ProtocolTypeManager.GetInstance<SkillActionDescription>(Convert.ToInt16(skillstypeId));
                type.Deserialize(reader);
                Skills.Add(type);
            }
        }
    }
}