namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Utils.IO;

    public class FightEntityDispositionInformations : EntityDispositionInformations
    {
        public new const ushort ProtocolId = 217;
        public override ushort TypeID => ProtocolId;
        public double CarryingCharacterId { get; set; }

        public FightEntityDispositionInformations(double carryingCharacterId)
        {
            CarryingCharacterId = carryingCharacterId;
        }

        public FightEntityDispositionInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(CarryingCharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CarryingCharacterId = reader.ReadDouble();
        }

    }
}
