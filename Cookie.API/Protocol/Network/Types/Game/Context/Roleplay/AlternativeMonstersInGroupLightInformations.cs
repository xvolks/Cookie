using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class AlternativeMonstersInGroupLightInformations : NetworkType
    {
        public const ushort ProtocolId = 394;

        public AlternativeMonstersInGroupLightInformations(int playerCount,
            List<MonsterInGroupLightInformations> monsters)
        {
            PlayerCount = playerCount;
            Monsters = monsters;
        }

        public AlternativeMonstersInGroupLightInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int PlayerCount { get; set; }
        public List<MonsterInGroupLightInformations> Monsters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PlayerCount);
            writer.WriteShort((short) Monsters.Count);
            for (var monstersIndex = 0; monstersIndex < Monsters.Count; monstersIndex++)
            {
                var objectToSend = Monsters[monstersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerCount = reader.ReadInt();
            var monstersCount = reader.ReadUShort();
            Monsters = new List<MonsterInGroupLightInformations>();
            for (var monstersIndex = 0; monstersIndex < monstersCount; monstersIndex++)
            {
                var objectToAdd = new MonsterInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Monsters.Add(objectToAdd);
            }
        }
    }
}