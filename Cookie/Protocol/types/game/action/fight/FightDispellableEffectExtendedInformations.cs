using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightDispellableEffectExtendedInformations : NetworkType
    {
        public const short ProtocolId = 208;
        public override short TypeId { get { return ProtocolId; } }

        public short ActionId = 0;
        public double SourceId = 0;
        public AbstractFightDispellableEffect Effect;

        public FightDispellableEffectExtendedInformations()
        {
        }

        public FightDispellableEffectExtendedInformations(
            short actionId,
            double sourceId,
            AbstractFightDispellableEffect effect
        )
        {
            ActionId = actionId;
            SourceId = sourceId;
            Effect = effect;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ActionId);
            writer.WriteDouble(SourceId);
            writer.WriteShort(Effect.TypeId);
            Effect.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionId = reader.ReadVarShort();
            SourceId = reader.ReadDouble();
            var effectTypeId = reader.ReadShort();
            Effect = new AbstractFightDispellableEffect();
            Effect.Deserialize(reader);
        }
    }
}