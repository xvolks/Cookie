namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Look;
    using Utils.IO;

    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public new const ushort ProtocolId = 3;
        public override ushort TypeID => ProtocolId;
        public ushort MonsterId { get; set; }
        public sbyte PowerLevel { get; set; }

        public GameRolePlayMutantInformations(ushort monsterId, sbyte powerLevel)
        {
            MonsterId = monsterId;
            PowerLevel = powerLevel;
        }

        public GameRolePlayMutantInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MonsterId);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadVarUhShort();
            PowerLevel = reader.ReadSByte();
        }

    }
}
