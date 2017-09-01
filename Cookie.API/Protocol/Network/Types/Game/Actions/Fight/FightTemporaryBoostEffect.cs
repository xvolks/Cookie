using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 209;

        public FightTemporaryBoostEffect(short delta)
        {
            Delta = delta;
        }

        public FightTemporaryBoostEffect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short Delta { get; set; }

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