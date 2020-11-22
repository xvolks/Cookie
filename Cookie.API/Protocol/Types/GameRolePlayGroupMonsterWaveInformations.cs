using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
    {
        public new const ushort ProtocolId = 464;

        public override ushort TypeID => ProtocolId;

        public sbyte NbWaves { get; set; }
        public List<GroupMonsterStaticInformations> Alternatives { get; set; }
        public GameRolePlayGroupMonsterWaveInformations() { }

        public GameRolePlayGroupMonsterWaveInformations( sbyte NbWaves, List<GroupMonsterStaticInformations> Alternatives ){
            this.NbWaves = NbWaves;
            this.Alternatives = Alternatives;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(NbWaves);
			writer.WriteShort((short)Alternatives.Count);
			foreach (var x in Alternatives)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbWaves = reader.ReadSByte();
            var AlternativesCount = reader.ReadShort();
            Alternatives = new List<GroupMonsterStaticInformations>();
            for (var i = 0; i < AlternativesCount; i++)
            {
                GroupMonsterStaticInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Alternatives.Add(objectToAdd);
            }
        }
    }
}
