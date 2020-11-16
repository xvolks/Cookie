using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public new const ushort ProtocolId = 396;

        public override ushort TypeID => ProtocolId;

        public List<AlternativeMonstersInGroupLightInformations> Alternatives { get; set; }
        public GroupMonsterStaticInformationsWithAlternatives() { }

        public GroupMonsterStaticInformationsWithAlternatives( List<AlternativeMonstersInGroupLightInformations> Alternatives ){
            this.Alternatives = Alternatives;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Alternatives.Count);
			foreach (var x in Alternatives)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var AlternativesCount = reader.ReadShort();
            Alternatives = new List<AlternativeMonstersInGroupLightInformations>();
            for (var i = 0; i < AlternativesCount; i++)
            {
                var objectToAdd = new AlternativeMonstersInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Alternatives.Add(objectToAdd);
            }
        }
    }
}
