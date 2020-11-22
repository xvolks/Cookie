using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobDescription : NetworkType
    {
        public const ushort ProtocolId = 101;

        public override ushort TypeID => ProtocolId;

        public sbyte JobId { get; set; }
        public List<SkillActionDescription> Skills { get; set; }
        public JobDescription() { }

        public JobDescription( sbyte JobId, List<SkillActionDescription> Skills ){
            this.JobId = JobId;
            this.Skills = Skills;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
			writer.WriteShort((short)Skills.Count);
			foreach (var x in Skills)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            var SkillsCount = reader.ReadShort();
            Skills = new List<SkillActionDescription>();
            for (var i = 0; i < SkillsCount; i++)
            {
                SkillActionDescription objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Skills.Add(objectToAdd);
            }
        }
    }
}
