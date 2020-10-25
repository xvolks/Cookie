using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
    {
        public new const uint ProtocolId = 5747;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;
        public List<short> Skills;

        public JobMultiCraftAvailableSkillsMessage(): base()
        {
        }

        public JobMultiCraftAvailableSkillsMessage(
            bool enabled,
            long playerId,
            List<short> skills
        ): base(
            enabled
        )
        {
            PlayerId = playerId;
            Skills = skills;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
            writer.WriteShort((short)Skills.Count());
            foreach (var current in Skills)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
            var countSkills = reader.ReadShort();
            Skills = new List<short>();
            for (short i = 0; i < countSkills; i++)
            {
                Skills.Add(reader.ReadVarShort());
            }
        }
    }
}