using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 214;

        public FightTemporaryBoostStateEffect(short stateId)
        {
            StateId = stateId;
        }

        public FightTemporaryBoostStateEffect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public short StateId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StateId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StateId = reader.ReadShort();
        }
    }
}