using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class InteractiveElement : NetworkType
    {
        public const ushort ProtocolId = 80;

        public override ushort TypeID => ProtocolId;

        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public List<InteractiveElementSkill> EnabledSkills { get; set; }
        public List<InteractiveElementSkill> DisabledSkills { get; set; }
        public bool OnCurrentMap { get; set; }
        public InteractiveElement() { }

        public InteractiveElement( int ElementId, int ElementTypeId, List<InteractiveElementSkill> EnabledSkills, List<InteractiveElementSkill> DisabledSkills, bool OnCurrentMap ){
            this.ElementId = ElementId;
            this.ElementTypeId = ElementTypeId;
            this.EnabledSkills = EnabledSkills;
            this.DisabledSkills = DisabledSkills;
            this.OnCurrentMap = OnCurrentMap;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteInt(ElementTypeId);
			writer.WriteShort((short)EnabledSkills.Count);
			foreach (var x in EnabledSkills)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)DisabledSkills.Count);
			foreach (var x in DisabledSkills)
			{
				x.Serialize(writer);
			}
            writer.WriteBoolean(OnCurrentMap);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElementId = reader.ReadInt();
            ElementTypeId = reader.ReadInt();
            var EnabledSkillsCount = reader.ReadShort();
            EnabledSkills = new List<InteractiveElementSkill>();
            for (var i = 0; i < EnabledSkillsCount; i++)
            {
                InteractiveElementSkill objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                EnabledSkills.Add(objectToAdd);
            }
            var DisabledSkillsCount = reader.ReadShort();
            DisabledSkills = new List<InteractiveElementSkill>();
            for (var i = 0; i < DisabledSkillsCount; i++)
            {
                InteractiveElementSkill objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                DisabledSkills.Add(objectToAdd);
            }
            OnCurrentMap = reader.ReadBoolean();
        }
    }
}
