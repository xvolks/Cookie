using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Protocol.Network.Types.Game.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    public class PrismFightersInformation : NetworkType
    {
        public const ushort ProtocolId = 443;

        public PrismFightersInformation(ushort subAreaId, ProtectedEntityWaitingForHelpInfo waitingForHelpInfo,
            List<CharacterMinimalPlusLookInformations> allyCharactersInformations,
            List<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
        {
            SubAreaId = subAreaId;
            WaitingForHelpInfo = waitingForHelpInfo;
            AllyCharactersInformations = allyCharactersInformations;
            EnemyCharactersInformations = enemyCharactersInformations;
        }

        public PrismFightersInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }
        public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
        public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            WaitingForHelpInfo.Serialize(writer);
            writer.WriteShort((short) AllyCharactersInformations.Count);
            for (var allyCharactersInformationsIndex = 0;
                allyCharactersInformationsIndex < AllyCharactersInformations.Count;
                allyCharactersInformationsIndex++)
            {
                var objectToSend = AllyCharactersInformations[allyCharactersInformationsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) EnemyCharactersInformations.Count);
            for (var enemyCharactersInformationsIndex = 0;
                enemyCharactersInformationsIndex < EnemyCharactersInformations.Count;
                enemyCharactersInformationsIndex++)
            {
                var objectToSend = EnemyCharactersInformations[enemyCharactersInformationsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
            var allyCharactersInformationsCount = reader.ReadUShort();
            AllyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var allyCharactersInformationsIndex = 0;
                allyCharactersInformationsIndex < allyCharactersInformationsCount;
                allyCharactersInformationsIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                AllyCharactersInformations.Add(objectToAdd);
            }
            var enemyCharactersInformationsCount = reader.ReadUShort();
            EnemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var enemyCharactersInformationsIndex = 0;
                enemyCharactersInformationsIndex < enemyCharactersInformationsCount;
                enemyCharactersInformationsIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                EnemyCharactersInformations.Add(objectToAdd);
            }
        }
    }
}