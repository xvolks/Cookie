using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GroupMonsterStaticInformations : NetworkType
    {
        public const ushort ProtocolId = 140;

        public override ushort TypeID => ProtocolId;

        public MonsterInGroupLightInformations MainCreatureLightInfos { get; set; }
        public List<MonsterInGroupInformations> Underlings { get; set; }
        public GroupMonsterStaticInformations() { }

        public GroupMonsterStaticInformations( MonsterInGroupLightInformations MainCreatureLightInfos, List<MonsterInGroupInformations> Underlings ){
            this.MainCreatureLightInfos = MainCreatureLightInfos;
            this.Underlings = Underlings;
        }

        public override void Serialize(IDataWriter writer)
        {
            MainCreatureLightInfos.Serialize(writer);
			writer.WriteShort((short)Underlings.Count);
			foreach (var x in Underlings)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MainCreatureLightInfos = new MonsterInGroupLightInformations();
            MainCreatureLightInfos.Deserialize(reader);
            var UnderlingsCount = reader.ReadShort();
            Underlings = new List<MonsterInGroupInformations>();
            for (var i = 0; i < UnderlingsCount; i++)
            {
                var objectToAdd = new MonsterInGroupInformations();
                objectToAdd.Deserialize(reader);
                Underlings.Add(objectToAdd);
            }
        }
    }
}
