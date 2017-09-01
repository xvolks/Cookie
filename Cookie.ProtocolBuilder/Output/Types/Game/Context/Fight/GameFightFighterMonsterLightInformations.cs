namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 455;
        public override ushort TypeID => ProtocolId;
        public ushort CreatureGenericId { get; set; }

        public GameFightFighterMonsterLightInformations(ushort creatureGenericId)
        {
            CreatureGenericId = creatureGenericId;
        }

        public GameFightFighterMonsterLightInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CreatureGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarUhShort();
        }

    }
}
