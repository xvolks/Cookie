using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public new const ushort ProtocolId = 396;

        public GroupMonsterStaticInformationsWithAlternatives(
            List<AlternativeMonstersInGroupLightInformations> alternatives)
        {
            Alternatives = alternatives;
        }

        public GroupMonsterStaticInformationsWithAlternatives()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<AlternativeMonstersInGroupLightInformations> Alternatives { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Alternatives.Count);
            for (var alternativesIndex = 0; alternativesIndex < Alternatives.Count; alternativesIndex++)
            {
                var objectToSend = Alternatives[alternativesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var alternativesCount = reader.ReadUShort();
            Alternatives = new List<AlternativeMonstersInGroupLightInformations>();
            for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
            {
                var objectToAdd = new AlternativeMonstersInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Alternatives.Add(objectToAdd);
            }
        }
    }
}