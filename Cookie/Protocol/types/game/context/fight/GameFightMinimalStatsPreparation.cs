using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightMinimalStatsPreparation : GameFightMinimalStats
    {
        public new const short ProtocolId = 360;
        public override short TypeId { get { return ProtocolId; } }

        public int Initiative = 0;

        public GameFightMinimalStatsPreparation(): base()
        {
        }

        public GameFightMinimalStatsPreparation(
            int lifePoints,
            int maxLifePoints,
            int baseMaxLifePoints,
            int permanentDamagePercent,
            int shieldPoints,
            short actionPoints,
            short maxActionPoints,
            short movementPoints,
            short maxMovementPoints,
            double summoner,
            bool summoned,
            short neutralElementResistPercent,
            short earthElementResistPercent,
            short waterElementResistPercent,
            short airElementResistPercent,
            short fireElementResistPercent,
            short neutralElementReduction,
            short earthElementReduction,
            short waterElementReduction,
            short airElementReduction,
            short fireElementReduction,
            short criticalDamageFixedResist,
            short pushDamageFixedResist,
            short pvpNeutralElementResistPercent,
            short pvpEarthElementResistPercent,
            short pvpWaterElementResistPercent,
            short pvpAirElementResistPercent,
            short pvpFireElementResistPercent,
            short pvpNeutralElementReduction,
            short pvpEarthElementReduction,
            short pvpWaterElementReduction,
            short pvpAirElementReduction,
            short pvpFireElementReduction,
            short dodgePALostProbability,
            short dodgePMLostProbability,
            short tackleBlock,
            short tackleEvade,
            short fixedDamageReflection,
            byte invisibilityState,
            short meleeDamageReceivedPercent,
            short rangedDamageReceivedPercent,
            short weaponDamageReceivedPercent,
            short spellDamageReceivedPercent,
            int initiative
        ): base(
            lifePoints,
            maxLifePoints,
            baseMaxLifePoints,
            permanentDamagePercent,
            shieldPoints,
            actionPoints,
            maxActionPoints,
            movementPoints,
            maxMovementPoints,
            summoner,
            summoned,
            neutralElementResistPercent,
            earthElementResistPercent,
            waterElementResistPercent,
            airElementResistPercent,
            fireElementResistPercent,
            neutralElementReduction,
            earthElementReduction,
            waterElementReduction,
            airElementReduction,
            fireElementReduction,
            criticalDamageFixedResist,
            pushDamageFixedResist,
            pvpNeutralElementResistPercent,
            pvpEarthElementResistPercent,
            pvpWaterElementResistPercent,
            pvpAirElementResistPercent,
            pvpFireElementResistPercent,
            pvpNeutralElementReduction,
            pvpEarthElementReduction,
            pvpWaterElementReduction,
            pvpAirElementReduction,
            pvpFireElementReduction,
            dodgePALostProbability,
            dodgePMLostProbability,
            tackleBlock,
            tackleEvade,
            fixedDamageReflection,
            invisibilityState,
            meleeDamageReceivedPercent,
            rangedDamageReceivedPercent,
            weaponDamageReceivedPercent,
            spellDamageReceivedPercent
        )
        {
            Initiative = initiative;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Initiative);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarInt();
        }
    }
}