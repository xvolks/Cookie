namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public new const ushort ProtocolId = 29;
        public override ushort TypeID => ProtocolId;
        public ushort CreatureGenericId { get; set; }
        public byte CreatureGrade { get; set; }

        public GameFightMonsterInformations(ushort creatureGenericId, byte creatureGrade)
        {
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
        }

        public GameFightMonsterInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CreatureGenericId);
            writer.WriteByte(CreatureGrade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarUhShort();
            CreatureGrade = reader.ReadByte();
        }

    }
}
