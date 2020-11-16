using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AlternativeMonstersInGroupLightInformations : NetworkType
    {
        public const ushort ProtocolId = 394;

        public override ushort TypeID => ProtocolId;

        public int PlayerCount { get; set; }
        public List<MonsterInGroupLightInformations> Monsters { get; set; }
        public AlternativeMonstersInGroupLightInformations() { }

        public AlternativeMonstersInGroupLightInformations( int PlayerCount, List<MonsterInGroupLightInformations> Monsters ){
            this.PlayerCount = PlayerCount;
            this.Monsters = Monsters;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PlayerCount);
			writer.WriteShort((short)Monsters.Count);
			foreach (var x in Monsters)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerCount = reader.ReadInt();
            var MonstersCount = reader.ReadShort();
            Monsters = new List<MonsterInGroupLightInformations>();
            for (var i = 0; i < MonstersCount; i++)
            {
                var objectToAdd = new MonsterInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Monsters.Add(objectToAdd);
            }
        }
    }
}
