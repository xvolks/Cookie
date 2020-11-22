using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorFightersInformation : NetworkType
    {
        public const ushort ProtocolId = 169;

        public override ushort TypeID => ProtocolId;

        public double CollectorId { get; set; }
        public List<CharacterMinimalPlusLookInformations> AllyCharactersInformations { get; set; }
        public List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations { get; set; }
        public TaxCollectorFightersInformation() { }

        public TaxCollectorFightersInformation( double CollectorId, List<CharacterMinimalPlusLookInformations> AllyCharactersInformations, List<CharacterMinimalPlusLookInformations> EnemyCharactersInformations ){
            this.CollectorId = CollectorId;
            this.AllyCharactersInformations = AllyCharactersInformations;
            this.EnemyCharactersInformations = EnemyCharactersInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CollectorId);
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
            CollectorId = reader.ReadDouble();
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
