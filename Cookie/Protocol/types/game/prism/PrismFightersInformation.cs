using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PrismFightersInformation : NetworkType
    {
        public const short ProtocolId = 443;
        public override short TypeId { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo;
        public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations;
        public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations;

        public PrismFightersInformation()
        {
        }

        public PrismFightersInformation(
            short subAreaId,
            ProtectedEntityWaitingForHelpInfo waitingForHelpInfo,
            List<CharacterMinimalPlusLookInformations> allyCharactersInformations,
            List<CharacterMinimalPlusLookInformations> enemyCharactersInformations
        )
        {
            SubAreaId = subAreaId;
            WaitingForHelpInfo = waitingForHelpInfo;
            AllyCharactersInformations = allyCharactersInformations;
            EnemyCharactersInformations = enemyCharactersInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            WaitingForHelpInfo.Serialize(writer);
            writer.WriteShort((short)AllyCharactersInformations.Count());
            foreach (var current in AllyCharactersInformations)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)EnemyCharactersInformations.Count());
            foreach (var current in EnemyCharactersInformations)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
            var countAllyCharactersInformations = reader.ReadShort();
            AllyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (short i = 0; i < countAllyCharactersInformations; i++)
            {
                var allyCharactersInformationstypeId = reader.ReadShort();
                CharacterMinimalPlusLookInformations type = new CharacterMinimalPlusLookInformations();
                type.Deserialize(reader);
                AllyCharactersInformations.Add(type);
            }
            var countEnemyCharactersInformations = reader.ReadShort();
            EnemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (short i = 0; i < countEnemyCharactersInformations; i++)
            {
                var enemyCharactersInformationstypeId = reader.ReadShort();
                CharacterMinimalPlusLookInformations type = new CharacterMinimalPlusLookInformations();
                type.Deserialize(reader);
                EnemyCharactersInformations.Add(type);
            }
        }
    }
}