namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    using Utils.IO;

    public class ObjectEffectCreature : ObjectEffect
    {
        public new const ushort ProtocolId = 71;
        public override ushort TypeID => ProtocolId;
        public ushort MonsterFamilyId { get; set; }

        public ObjectEffectCreature(ushort monsterFamilyId)
        {
            MonsterFamilyId = monsterFamilyId;
        }

        public ObjectEffectCreature() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MonsterFamilyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterFamilyId = reader.ReadVarUhShort();
        }

    }
}
