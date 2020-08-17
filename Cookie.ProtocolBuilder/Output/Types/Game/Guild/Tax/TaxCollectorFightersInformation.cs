namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    using Types.Game.Character;
    using System.Collections.Generic;
    using Utils.IO;

    public class TaxCollectorFightersInformation : NetworkType
    {
        public const ushort ProtocolId = 169;
        public override ushort TypeID => ProtocolId;
        public int CollectorId { get; set; }
        public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
        public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }

        public TaxCollectorFightersInformation(int collectorId, List<CharacterMinimalPlusLookInformations> allyCharactersInformations, List<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
        {
            CollectorId = collectorId;
            AllyCharactersInformations = allyCharactersInformations;
            EnemyCharactersInformations = enemyCharactersInformations;
        }

        public TaxCollectorFightersInformation() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(CollectorId);
            writer.WriteShort((short)AllyCharactersInformations.Count);
            for (var allyCharactersInformationsIndex = 0; allyCharactersInformationsIndex < AllyCharactersInformations.Count; allyCharactersInformationsIndex++)
            {
                var objectToSend = AllyCharactersInformations[allyCharactersInformationsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short)EnemyCharactersInformations.Count);
            for (var enemyCharactersInformationsIndex = 0; enemyCharactersInformationsIndex < EnemyCharactersInformations.Count; enemyCharactersInformationsIndex++)
            {
                var objectToSend = EnemyCharactersInformations[enemyCharactersInformationsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorId = reader.ReadInt();
            var allyCharactersInformationsCount = reader.ReadUShort();
            AllyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var allyCharactersInformationsIndex = 0; allyCharactersInformationsIndex < allyCharactersInformationsCount; allyCharactersInformationsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                AllyCharactersInformations.Add(objectToAdd);
            }
            var enemyCharactersInformationsCount = reader.ReadUShort();
            EnemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var enemyCharactersInformationsIndex = 0; enemyCharactersInformationsIndex < enemyCharactersInformationsCount; enemyCharactersInformationsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                EnemyCharactersInformations.Add(objectToAdd);
            }
        }

    }
}
