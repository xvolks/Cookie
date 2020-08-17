namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    using Utils.IO;

    public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 209;
        public override ushort TypeID => ProtocolId;
        public short Delta { get; set; }

        public FightTemporaryBoostEffect(short delta)
        {
            Delta = delta;
        }

        public FightTemporaryBoostEffect() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Delta = reader.ReadShort();
        }

    }
}
