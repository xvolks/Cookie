using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6221;

        public GameActionFightSpellImmunityMessage(double targetId, ushort spellId)
        {
            TargetId = targetId;
            SpellId = spellId;
        }

        public GameActionFightSpellImmunityMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public ushort SpellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            SpellId = reader.ReadVarUhShort();
        }
    }
}