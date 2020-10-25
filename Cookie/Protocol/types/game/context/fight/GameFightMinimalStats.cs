using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightMinimalStats : NetworkType
    {
        public const short ProtocolId = 31;
        public override short TypeId { get { return ProtocolId; } }

        public int LifePoints = 0;
        public int MaxLifePoints = 0;
        public int BaseMaxLifePoints = 0;
        public int PermanentDamagePercent = 0;
        public int ShieldPoints = 0;
        public short ActionPoints = 0;
        public short MaxActionPoints = 0;
        public short MovementPoints = 0;
        public short MaxMovementPoints = 0;
        public double Summoner = 0;
        public bool Summoned = false;
        public short NeutralElementResistPercent = 0;
        public short EarthElementResistPercent = 0;
        public short WaterElementResistPercent = 0;
        public short AirElementResistPercent = 0;
        public short FireElementResistPercent = 0;
        public short NeutralElementReduction = 0;
        public short EarthElementReduction = 0;
        public short WaterElementReduction = 0;
        public short AirElementReduction = 0;
        public short FireElementReduction = 0;
        public short CriticalDamageFixedResist = 0;
        public short PushDamageFixedResist = 0;
        public short PvpNeutralElementResistPercent = 0;
        public short PvpEarthElementResistPercent = 0;
        public short PvpWaterElementResistPercent = 0;
        public short PvpAirElementResistPercent = 0;
        public short PvpFireElementResistPercent = 0;
        public short PvpNeutralElementReduction = 0;
        public short PvpEarthElementReduction = 0;
        public short PvpWaterElementReduction = 0;
        public short PvpAirElementReduction = 0;
        public short PvpFireElementReduction = 0;
        public short DodgePALostProbability = 0;
        public short DodgePMLostProbability = 0;
        public short TackleBlock = 0;
        public short TackleEvade = 0;
        public short FixedDamageReflection = 0;
        public byte InvisibilityState = 0;
        public short MeleeDamageReceivedPercent = 0;
        public short RangedDamageReceivedPercent = 0;
        public short WeaponDamageReceivedPercent = 0;
        public short SpellDamageReceivedPercent = 0;

        public GameFightMinimalStats()
        {
        }

        public GameFightMinimalStats(
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
            short spellDamageReceivedPercent
        )
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            BaseMaxLifePoints = baseMaxLifePoints;
            PermanentDamagePercent = permanentDamagePercent;
            ShieldPoints = shieldPoints;
            ActionPoints = actionPoints;
            MaxActionPoints = maxActionPoints;
            MovementPoints = movementPoints;
            MaxMovementPoints = maxMovementPoints;
            Summoner = summoner;
            Summoned = summoned;
            NeutralElementResistPercent = neutralElementResistPercent;
            EarthElementResistPercent = earthElementResistPercent;
            WaterElementResistPercent = waterElementResistPercent;
            AirElementResistPercent = airElementResistPercent;
            FireElementResistPercent = fireElementResistPercent;
            NeutralElementReduction = neutralElementReduction;
            EarthElementReduction = earthElementReduction;
            WaterElementReduction = waterElementReduction;
            AirElementReduction = airElementReduction;
            FireElementReduction = fireElementReduction;
            CriticalDamageFixedResist = criticalDamageFixedResist;
            PushDamageFixedResist = pushDamageFixedResist;
            PvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            PvpEarthElementResistPercent = pvpEarthElementResistPercent;
            PvpWaterElementResistPercent = pvpWaterElementResistPercent;
            PvpAirElementResistPercent = pvpAirElementResistPercent;
            PvpFireElementResistPercent = pvpFireElementResistPercent;
            PvpNeutralElementReduction = pvpNeutralElementReduction;
            PvpEarthElementReduction = pvpEarthElementReduction;
            PvpWaterElementReduction = pvpWaterElementReduction;
            PvpAirElementReduction = pvpAirElementReduction;
            PvpFireElementReduction = pvpFireElementReduction;
            DodgePALostProbability = dodgePALostProbability;
            DodgePMLostProbability = dodgePMLostProbability;
            TackleBlock = tackleBlock;
            TackleEvade = tackleEvade;
            FixedDamageReflection = fixedDamageReflection;
            InvisibilityState = invisibilityState;
            MeleeDamageReceivedPercent = meleeDamageReceivedPercent;
            RangedDamageReceivedPercent = rangedDamageReceivedPercent;
            WeaponDamageReceivedPercent = weaponDamageReceivedPercent;
            SpellDamageReceivedPercent = spellDamageReceivedPercent;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
            writer.WriteVarInt(BaseMaxLifePoints);
            writer.WriteVarInt(PermanentDamagePercent);
            writer.WriteVarInt(ShieldPoints);
            writer.WriteVarShort(ActionPoints);
            writer.WriteVarShort(MaxActionPoints);
            writer.WriteVarShort(MovementPoints);
            writer.WriteVarShort(MaxMovementPoints);
            writer.WriteDouble(Summoner);
            writer.WriteBoolean(Summoned);
            writer.WriteVarShort(NeutralElementResistPercent);
            writer.WriteVarShort(EarthElementResistPercent);
            writer.WriteVarShort(WaterElementResistPercent);
            writer.WriteVarShort(AirElementResistPercent);
            writer.WriteVarShort(FireElementResistPercent);
            writer.WriteVarShort(NeutralElementReduction);
            writer.WriteVarShort(EarthElementReduction);
            writer.WriteVarShort(WaterElementReduction);
            writer.WriteVarShort(AirElementReduction);
            writer.WriteVarShort(FireElementReduction);
            writer.WriteVarShort(CriticalDamageFixedResist);
            writer.WriteVarShort(PushDamageFixedResist);
            writer.WriteVarShort(PvpNeutralElementResistPercent);
            writer.WriteVarShort(PvpEarthElementResistPercent);
            writer.WriteVarShort(PvpWaterElementResistPercent);
            writer.WriteVarShort(PvpAirElementResistPercent);
            writer.WriteVarShort(PvpFireElementResistPercent);
            writer.WriteVarShort(PvpNeutralElementReduction);
            writer.WriteVarShort(PvpEarthElementReduction);
            writer.WriteVarShort(PvpWaterElementReduction);
            writer.WriteVarShort(PvpAirElementReduction);
            writer.WriteVarShort(PvpFireElementReduction);
            writer.WriteVarShort(DodgePALostProbability);
            writer.WriteVarShort(DodgePMLostProbability);
            writer.WriteVarShort(TackleBlock);
            writer.WriteVarShort(TackleEvade);
            writer.WriteVarShort(FixedDamageReflection);
            writer.WriteByte(InvisibilityState);
            writer.WriteVarShort(MeleeDamageReceivedPercent);
            writer.WriteVarShort(RangedDamageReceivedPercent);
            writer.WriteVarShort(WeaponDamageReceivedPercent);
            writer.WriteVarShort(SpellDamageReceivedPercent);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
            BaseMaxLifePoints = reader.ReadVarInt();
            PermanentDamagePercent = reader.ReadVarInt();
            ShieldPoints = reader.ReadVarInt();
            ActionPoints = reader.ReadVarShort();
            MaxActionPoints = reader.ReadVarShort();
            MovementPoints = reader.ReadVarShort();
            MaxMovementPoints = reader.ReadVarShort();
            Summoner = reader.ReadDouble();
            Summoned = reader.ReadBoolean();
            NeutralElementResistPercent = reader.ReadVarShort();
            EarthElementResistPercent = reader.ReadVarShort();
            WaterElementResistPercent = reader.ReadVarShort();
            AirElementResistPercent = reader.ReadVarShort();
            FireElementResistPercent = reader.ReadVarShort();
            NeutralElementReduction = reader.ReadVarShort();
            EarthElementReduction = reader.ReadVarShort();
            WaterElementReduction = reader.ReadVarShort();
            AirElementReduction = reader.ReadVarShort();
            FireElementReduction = reader.ReadVarShort();
            CriticalDamageFixedResist = reader.ReadVarShort();
            PushDamageFixedResist = reader.ReadVarShort();
            PvpNeutralElementResistPercent = reader.ReadVarShort();
            PvpEarthElementResistPercent = reader.ReadVarShort();
            PvpWaterElementResistPercent = reader.ReadVarShort();
            PvpAirElementResistPercent = reader.ReadVarShort();
            PvpFireElementResistPercent = reader.ReadVarShort();
            PvpNeutralElementReduction = reader.ReadVarShort();
            PvpEarthElementReduction = reader.ReadVarShort();
            PvpWaterElementReduction = reader.ReadVarShort();
            PvpAirElementReduction = reader.ReadVarShort();
            PvpFireElementReduction = reader.ReadVarShort();
            DodgePALostProbability = reader.ReadVarShort();
            DodgePMLostProbability = reader.ReadVarShort();
            TackleBlock = reader.ReadVarShort();
            TackleEvade = reader.ReadVarShort();
            FixedDamageReflection = reader.ReadVarShort();
            InvisibilityState = reader.ReadByte();
            MeleeDamageReceivedPercent = reader.ReadVarShort();
            RangedDamageReceivedPercent = reader.ReadVarShort();
            WeaponDamageReceivedPercent = reader.ReadVarShort();
            SpellDamageReceivedPercent = reader.ReadVarShort();
        }
    }
}