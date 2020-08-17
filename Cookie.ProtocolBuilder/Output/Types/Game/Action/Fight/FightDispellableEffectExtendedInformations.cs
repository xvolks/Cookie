namespace Cookie.API.Protocol.Network.Types.Game.Action.Fight
{
    using Types.Game.Actions.Fight;
    using Utils.IO;

    public class FightDispellableEffectExtendedInformations : NetworkType
    {
        public const ushort ProtocolId = 208;
        public override ushort TypeID => ProtocolId;
        public ushort ActionId { get; set; }
        public double SourceId { get; set; }
        public AbstractFightDispellableEffect Effect { get; set; }

        public FightDispellableEffectExtendedInformations(ushort actionId, double sourceId, AbstractFightDispellableEffect effect)
        {
            ActionId = actionId;
            SourceId = sourceId;
            Effect = effect;
        }

        public FightDispellableEffectExtendedInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(SourceId);
            writer.WriteUShort(Effect.TypeID);
            Effect.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            SourceId = reader.ReadDouble();
            Effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadUShort());
            Effect.Deserialize(reader);
        }

    }
}
