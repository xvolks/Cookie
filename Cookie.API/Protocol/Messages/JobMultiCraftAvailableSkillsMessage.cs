using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
    {
        public new const ushort ProtocolId = 5747;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public List<short> Skills { get; set; }
        public JobMultiCraftAvailableSkillsMessage() { }

        public JobMultiCraftAvailableSkillsMessage( ulong PlayerId, List<short> Skills ){
            this.PlayerId = PlayerId;
            this.Skills = Skills;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
			writer.WriteShort((short)Skills.Count);
			foreach (var x in Skills)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            var SkillsCount = reader.ReadShort();
            Skills = new List<short>();
            for (var i = 0; i < SkillsCount; i++)
            {
                Skills.Add(reader.ReadVarShort());
            }
        }
    }
}
