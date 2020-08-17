namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
    {
        public new const ushort ProtocolId = 464;
        public override ushort TypeID => ProtocolId;
        public byte NbWaves { get; set; }
        public List<GroupMonsterStaticInformations> Alternatives { get; set; }

        public GameRolePlayGroupMonsterWaveInformations(byte nbWaves, List<GroupMonsterStaticInformations> alternatives)
        {
            NbWaves = nbWaves;
            Alternatives = alternatives;
        }

        public GameRolePlayGroupMonsterWaveInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbWaves);
            writer.WriteShort((short)Alternatives.Count);
            for (var alternativesIndex = 0; alternativesIndex < Alternatives.Count; alternativesIndex++)
            {
                var objectToSend = Alternatives[alternativesIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbWaves = reader.ReadByte();
            var alternativesCount = reader.ReadUShort();
            Alternatives = new List<GroupMonsterStaticInformations>();
            for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Alternatives.Add(objectToAdd);
            }
        }

    }
}
