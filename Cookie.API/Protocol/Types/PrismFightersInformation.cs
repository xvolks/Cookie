using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PrismFightersInformation : NetworkType
    {
        public const ushort ProtocolId = 443;

        public override ushort TypeID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }
        public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
        public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }
        public PrismFightersInformation() { }

        public PrismFightersInformation( ushort SubAreaId, ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo, List<CharacterMinimalPlusLookInformations> AllyCharactersInformations, List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations ){
            this.SubAreaId = SubAreaId;
            this.WaitingForHelpInfo = WaitingForHelpInfo;
            this.AllyCharactersInformations = AllyCharactersInformations;
            this.EnemyCharactersInformations = EnemyCharactersInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            WaitingForHelpInfo.Serialize(writer);
			writer.WriteShort((short)AllyCharactersInformations.Count);
			foreach (var x in AllyCharactersInformations)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)EnemyCharactersInformations.Count);
			foreach (var x in EnemyCharactersInformations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
            WaitingForHelpInfo.Deserialize(reader);
            var AllyCharactersInformationsCount = reader.ReadShort();
            AllyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var i = 0; i < AllyCharactersInformationsCount; i++)
            {
                CharacterMinimalPlusLookInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                AllyCharactersInformations.Add(objectToAdd);
            }
            var EnemyCharactersInformationsCount = reader.ReadShort();
            EnemyCharactersInformations = new List<CharacterMinimalPlusLookInformations>();
            for (var i = 0; i < EnemyCharactersInformationsCount; i++)
            {
                CharacterMinimalPlusLookInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                EnemyCharactersInformations.Add(objectToAdd);
            }
        }
    }
}
