using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterCharacteristicsInformations : NetworkType
    {
        public const short ProtocolId = 8;
        public override short TypeId { get { return ProtocolId; } }

        public long Experience = 0;
        public long ExperienceLevelFloor = 0;
        public long ExperienceNextLevelFloor = 0;
        public long ExperienceBonusLimit = 0;
        public long Kamas = 0;
        public short StatsPoints = 0;
        public short AdditionnalPoints = 0;
        public short SpellsPoints = 0;
        public ActorExtendedAlignmentInformations AlignmentInfos;
        public int LifePoints = 0;
        public int MaxLifePoints = 0;
        public short EnergyPoints = 0;
        public short MaxEnergyPoints = 0;
        public short ActionPointsCurrent = 0;
        public short MovementPointsCurrent = 0;
        public CharacterBaseCharacteristic Initiative;
        public CharacterBaseCharacteristic Prospecting;
        public CharacterBaseCharacteristic ActionPoints;
        public CharacterBaseCharacteristic MovementPoints;
        public CharacterBaseCharacteristic Strength;
        public CharacterBaseCharacteristic Vitality;
        public CharacterBaseCharacteristic Wisdom;
        public CharacterBaseCharacteristic Chance;
        public CharacterBaseCharacteristic Agility;
        public CharacterBaseCharacteristic Intelligence;
        public CharacterBaseCharacteristic Range;
        public CharacterBaseCharacteristic SummonableCreaturesBoost;
        public CharacterBaseCharacteristic Reflect;
        public CharacterBaseCharacteristic CriticalHit;
        public short CriticalHitWeapon = 0;
        public CharacterBaseCharacteristic CriticalMiss;
        public CharacterBaseCharacteristic HealBonus;
        public CharacterBaseCharacteristic AllDamagesBonus;
        public CharacterBaseCharacteristic WeaponDamagesBonusPercent;
        public CharacterBaseCharacteristic DamagesBonusPercent;
        public CharacterBaseCharacteristic TrapBonus;
        public CharacterBaseCharacteristic TrapBonusPercent;
        public CharacterBaseCharacteristic GlyphBonusPercent;
        public CharacterBaseCharacteristic RuneBonusPercent;
        public CharacterBaseCharacteristic PermanentDamagePercent;
        public CharacterBaseCharacteristic TackleBlock;
        public CharacterBaseCharacteristic TackleEvade;
        public CharacterBaseCharacteristic PAAttack;
        public CharacterBaseCharacteristic PMAttack;
        public CharacterBaseCharacteristic PushDamageBonus;
        public CharacterBaseCharacteristic CriticalDamageBonus;
        public CharacterBaseCharacteristic NeutralDamageBonus;
        public CharacterBaseCharacteristic EarthDamageBonus;
        public CharacterBaseCharacteristic WaterDamageBonus;
        public CharacterBaseCharacteristic AirDamageBonus;
        public CharacterBaseCharacteristic FireDamageBonus;
        public CharacterBaseCharacteristic DodgePALostProbability;
        public CharacterBaseCharacteristic DodgePMLostProbability;
        public CharacterBaseCharacteristic NeutralElementResistPercent;
        public CharacterBaseCharacteristic EarthElementResistPercent;
        public CharacterBaseCharacteristic WaterElementResistPercent;
        public CharacterBaseCharacteristic AirElementResistPercent;
        public CharacterBaseCharacteristic FireElementResistPercent;
        public CharacterBaseCharacteristic NeutralElementReduction;
        public CharacterBaseCharacteristic EarthElementReduction;
        public CharacterBaseCharacteristic WaterElementReduction;
        public CharacterBaseCharacteristic AirElementReduction;
        public CharacterBaseCharacteristic FireElementReduction;
        public CharacterBaseCharacteristic PushDamageReduction;
        public CharacterBaseCharacteristic CriticalDamageReduction;
        public CharacterBaseCharacteristic PvpNeutralElementResistPercent;
        public CharacterBaseCharacteristic PvpEarthElementResistPercent;
        public CharacterBaseCharacteristic PvpWaterElementResistPercent;
        public CharacterBaseCharacteristic PvpAirElementResistPercent;
        public CharacterBaseCharacteristic PvpFireElementResistPercent;
        public CharacterBaseCharacteristic PvpNeutralElementReduction;
        public CharacterBaseCharacteristic PvpEarthElementReduction;
        public CharacterBaseCharacteristic PvpWaterElementReduction;
        public CharacterBaseCharacteristic PvpAirElementReduction;
        public CharacterBaseCharacteristic PvpFireElementReduction;
        public CharacterBaseCharacteristic MeleeDamageDonePercent;
        public CharacterBaseCharacteristic MeleeDamageReceivedPercent;
        public CharacterBaseCharacteristic RangedDamageDonePercent;
        public CharacterBaseCharacteristic RangedDamageReceivedPercent;
        public CharacterBaseCharacteristic WeaponDamageDonePercent;
        public CharacterBaseCharacteristic WeaponDamageReceivedPercent;
        public CharacterBaseCharacteristic SpellDamageDonePercent;
        public CharacterBaseCharacteristic SpellDamageReceivedPercent;
        public List<CharacterSpellModification> SpellModifications;
        public int ProbationTime = 0;

        public CharacterCharacteristicsInformations()
        {
        }

        public CharacterCharacteristicsInformations(
            long experience,
            long experienceLevelFloor,
            long experienceNextLevelFloor,
            long experienceBonusLimit,
            long kamas,
            short statsPoints,
            short additionnalPoints,
            short spellsPoints,
            ActorExtendedAlignmentInformations alignmentInfos,
            int lifePoints,
            int maxLifePoints,
            short energyPoints,
            short maxEnergyPoints,
            short actionPointsCurrent,
            short movementPointsCurrent,
            CharacterBaseCharacteristic initiative,
            CharacterBaseCharacteristic prospecting,
            CharacterBaseCharacteristic actionPoints,
            CharacterBaseCharacteristic movementPoints,
            CharacterBaseCharacteristic strength,
            CharacterBaseCharacteristic vitality,
            CharacterBaseCharacteristic wisdom,
            CharacterBaseCharacteristic chance,
            CharacterBaseCharacteristic agility,
            CharacterBaseCharacteristic intelligence,
            CharacterBaseCharacteristic range,
            CharacterBaseCharacteristic summonableCreaturesBoost,
            CharacterBaseCharacteristic reflect,
            CharacterBaseCharacteristic criticalHit,
            short criticalHitWeapon,
            CharacterBaseCharacteristic criticalMiss,
            CharacterBaseCharacteristic healBonus,
            CharacterBaseCharacteristic allDamagesBonus,
            CharacterBaseCharacteristic weaponDamagesBonusPercent,
            CharacterBaseCharacteristic damagesBonusPercent,
            CharacterBaseCharacteristic trapBonus,
            CharacterBaseCharacteristic trapBonusPercent,
            CharacterBaseCharacteristic glyphBonusPercent,
            CharacterBaseCharacteristic runeBonusPercent,
            CharacterBaseCharacteristic permanentDamagePercent,
            CharacterBaseCharacteristic tackleBlock,
            CharacterBaseCharacteristic tackleEvade,
            CharacterBaseCharacteristic paattack,
            CharacterBaseCharacteristic pmattack,
            CharacterBaseCharacteristic pushDamageBonus,
            CharacterBaseCharacteristic criticalDamageBonus,
            CharacterBaseCharacteristic neutralDamageBonus,
            CharacterBaseCharacteristic earthDamageBonus,
            CharacterBaseCharacteristic waterDamageBonus,
            CharacterBaseCharacteristic airDamageBonus,
            CharacterBaseCharacteristic fireDamageBonus,
            CharacterBaseCharacteristic dodgePALostProbability,
            CharacterBaseCharacteristic dodgePMLostProbability,
            CharacterBaseCharacteristic neutralElementResistPercent,
            CharacterBaseCharacteristic earthElementResistPercent,
            CharacterBaseCharacteristic waterElementResistPercent,
            CharacterBaseCharacteristic airElementResistPercent,
            CharacterBaseCharacteristic fireElementResistPercent,
            CharacterBaseCharacteristic neutralElementReduction,
            CharacterBaseCharacteristic earthElementReduction,
            CharacterBaseCharacteristic waterElementReduction,
            CharacterBaseCharacteristic airElementReduction,
            CharacterBaseCharacteristic fireElementReduction,
            CharacterBaseCharacteristic pushDamageReduction,
            CharacterBaseCharacteristic criticalDamageReduction,
            CharacterBaseCharacteristic pvpNeutralElementResistPercent,
            CharacterBaseCharacteristic pvpEarthElementResistPercent,
            CharacterBaseCharacteristic pvpWaterElementResistPercent,
            CharacterBaseCharacteristic pvpAirElementResistPercent,
            CharacterBaseCharacteristic pvpFireElementResistPercent,
            CharacterBaseCharacteristic pvpNeutralElementReduction,
            CharacterBaseCharacteristic pvpEarthElementReduction,
            CharacterBaseCharacteristic pvpWaterElementReduction,
            CharacterBaseCharacteristic pvpAirElementReduction,
            CharacterBaseCharacteristic pvpFireElementReduction,
            CharacterBaseCharacteristic meleeDamageDonePercent,
            CharacterBaseCharacteristic meleeDamageReceivedPercent,
            CharacterBaseCharacteristic rangedDamageDonePercent,
            CharacterBaseCharacteristic rangedDamageReceivedPercent,
            CharacterBaseCharacteristic weaponDamageDonePercent,
            CharacterBaseCharacteristic weaponDamageReceivedPercent,
            CharacterBaseCharacteristic spellDamageDonePercent,
            CharacterBaseCharacteristic spellDamageReceivedPercent,
            List<CharacterSpellModification> spellModifications,
            int probationTime
        )
        {
            Experience = experience;
            ExperienceLevelFloor = experienceLevelFloor;
            ExperienceNextLevelFloor = experienceNextLevelFloor;
            ExperienceBonusLimit = experienceBonusLimit;
            Kamas = kamas;
            StatsPoints = statsPoints;
            AdditionnalPoints = additionnalPoints;
            SpellsPoints = spellsPoints;
            AlignmentInfos = alignmentInfos;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            EnergyPoints = energyPoints;
            MaxEnergyPoints = maxEnergyPoints;
            ActionPointsCurrent = actionPointsCurrent;
            MovementPointsCurrent = movementPointsCurrent;
            Initiative = initiative;
            Prospecting = prospecting;
            ActionPoints = actionPoints;
            MovementPoints = movementPoints;
            Strength = strength;
            Vitality = vitality;
            Wisdom = wisdom;
            Chance = chance;
            Agility = agility;
            Intelligence = intelligence;
            Range = range;
            SummonableCreaturesBoost = summonableCreaturesBoost;
            Reflect = reflect;
            CriticalHit = criticalHit;
            CriticalHitWeapon = criticalHitWeapon;
            CriticalMiss = criticalMiss;
            HealBonus = healBonus;
            AllDamagesBonus = allDamagesBonus;
            WeaponDamagesBonusPercent = weaponDamagesBonusPercent;
            DamagesBonusPercent = damagesBonusPercent;
            TrapBonus = trapBonus;
            TrapBonusPercent = trapBonusPercent;
            GlyphBonusPercent = glyphBonusPercent;
            RuneBonusPercent = runeBonusPercent;
            PermanentDamagePercent = permanentDamagePercent;
            TackleBlock = tackleBlock;
            TackleEvade = tackleEvade;
            PAAttack = paattack;
            PMAttack = pmattack;
            PushDamageBonus = pushDamageBonus;
            CriticalDamageBonus = criticalDamageBonus;
            NeutralDamageBonus = neutralDamageBonus;
            EarthDamageBonus = earthDamageBonus;
            WaterDamageBonus = waterDamageBonus;
            AirDamageBonus = airDamageBonus;
            FireDamageBonus = fireDamageBonus;
            DodgePALostProbability = dodgePALostProbability;
            DodgePMLostProbability = dodgePMLostProbability;
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
            PushDamageReduction = pushDamageReduction;
            CriticalDamageReduction = criticalDamageReduction;
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
            MeleeDamageDonePercent = meleeDamageDonePercent;
            MeleeDamageReceivedPercent = meleeDamageReceivedPercent;
            RangedDamageDonePercent = rangedDamageDonePercent;
            RangedDamageReceivedPercent = rangedDamageReceivedPercent;
            WeaponDamageDonePercent = weaponDamageDonePercent;
            WeaponDamageReceivedPercent = weaponDamageReceivedPercent;
            SpellDamageDonePercent = spellDamageDonePercent;
            SpellDamageReceivedPercent = spellDamageReceivedPercent;
            SpellModifications = spellModifications;
            ProbationTime = probationTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Experience);
            writer.WriteVarLong(ExperienceLevelFloor);
            writer.WriteVarLong(ExperienceNextLevelFloor);
            writer.WriteVarLong(ExperienceBonusLimit);
            writer.WriteVarLong(Kamas);
            writer.WriteVarShort(StatsPoints);
            writer.WriteVarShort(AdditionnalPoints);
            writer.WriteVarShort(SpellsPoints);
            AlignmentInfos.Serialize(writer);
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
            writer.WriteVarShort(EnergyPoints);
            writer.WriteVarShort(MaxEnergyPoints);
            writer.WriteVarShort(ActionPointsCurrent);
            writer.WriteVarShort(MovementPointsCurrent);
            Initiative.Serialize(writer);
            Prospecting.Serialize(writer);
            ActionPoints.Serialize(writer);
            MovementPoints.Serialize(writer);
            Strength.Serialize(writer);
            Vitality.Serialize(writer);
            Wisdom.Serialize(writer);
            Chance.Serialize(writer);
            Agility.Serialize(writer);
            Intelligence.Serialize(writer);
            Range.Serialize(writer);
            SummonableCreaturesBoost.Serialize(writer);
            Reflect.Serialize(writer);
            CriticalHit.Serialize(writer);
            writer.WriteVarShort(CriticalHitWeapon);
            CriticalMiss.Serialize(writer);
            HealBonus.Serialize(writer);
            AllDamagesBonus.Serialize(writer);
            WeaponDamagesBonusPercent.Serialize(writer);
            DamagesBonusPercent.Serialize(writer);
            TrapBonus.Serialize(writer);
            TrapBonusPercent.Serialize(writer);
            GlyphBonusPercent.Serialize(writer);
            RuneBonusPercent.Serialize(writer);
            PermanentDamagePercent.Serialize(writer);
            TackleBlock.Serialize(writer);
            TackleEvade.Serialize(writer);
            PAAttack.Serialize(writer);
            PMAttack.Serialize(writer);
            PushDamageBonus.Serialize(writer);
            CriticalDamageBonus.Serialize(writer);
            NeutralDamageBonus.Serialize(writer);
            EarthDamageBonus.Serialize(writer);
            WaterDamageBonus.Serialize(writer);
            AirDamageBonus.Serialize(writer);
            FireDamageBonus.Serialize(writer);
            DodgePALostProbability.Serialize(writer);
            DodgePMLostProbability.Serialize(writer);
            NeutralElementResistPercent.Serialize(writer);
            EarthElementResistPercent.Serialize(writer);
            WaterElementResistPercent.Serialize(writer);
            AirElementResistPercent.Serialize(writer);
            FireElementResistPercent.Serialize(writer);
            NeutralElementReduction.Serialize(writer);
            EarthElementReduction.Serialize(writer);
            WaterElementReduction.Serialize(writer);
            AirElementReduction.Serialize(writer);
            FireElementReduction.Serialize(writer);
            PushDamageReduction.Serialize(writer);
            CriticalDamageReduction.Serialize(writer);
            PvpNeutralElementResistPercent.Serialize(writer);
            PvpEarthElementResistPercent.Serialize(writer);
            PvpWaterElementResistPercent.Serialize(writer);
            PvpAirElementResistPercent.Serialize(writer);
            PvpFireElementResistPercent.Serialize(writer);
            PvpNeutralElementReduction.Serialize(writer);
            PvpEarthElementReduction.Serialize(writer);
            PvpWaterElementReduction.Serialize(writer);
            PvpAirElementReduction.Serialize(writer);
            PvpFireElementReduction.Serialize(writer);
            MeleeDamageDonePercent.Serialize(writer);
            MeleeDamageReceivedPercent.Serialize(writer);
            RangedDamageDonePercent.Serialize(writer);
            RangedDamageReceivedPercent.Serialize(writer);
            WeaponDamageDonePercent.Serialize(writer);
            WeaponDamageReceivedPercent.Serialize(writer);
            SpellDamageDonePercent.Serialize(writer);
            SpellDamageReceivedPercent.Serialize(writer);
            writer.WriteShort((short)SpellModifications.Count());
            foreach (var current in SpellModifications)
            {
                current.Serialize(writer);
            }
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Experience = reader.ReadVarLong();
            ExperienceLevelFloor = reader.ReadVarLong();
            ExperienceNextLevelFloor = reader.ReadVarLong();
            ExperienceBonusLimit = reader.ReadVarLong();
            Kamas = reader.ReadVarLong();
            StatsPoints = reader.ReadVarShort();
            AdditionnalPoints = reader.ReadVarShort();
            SpellsPoints = reader.ReadVarShort();
            AlignmentInfos = new ActorExtendedAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
            EnergyPoints = reader.ReadVarShort();
            MaxEnergyPoints = reader.ReadVarShort();
            ActionPointsCurrent = reader.ReadVarShort();
            MovementPointsCurrent = reader.ReadVarShort();
            Initiative = new CharacterBaseCharacteristic();
            Initiative.Deserialize(reader);
            Prospecting = new CharacterBaseCharacteristic();
            Prospecting.Deserialize(reader);
            ActionPoints = new CharacterBaseCharacteristic();
            ActionPoints.Deserialize(reader);
            MovementPoints = new CharacterBaseCharacteristic();
            MovementPoints.Deserialize(reader);
            Strength = new CharacterBaseCharacteristic();
            Strength.Deserialize(reader);
            Vitality = new CharacterBaseCharacteristic();
            Vitality.Deserialize(reader);
            Wisdom = new CharacterBaseCharacteristic();
            Wisdom.Deserialize(reader);
            Chance = new CharacterBaseCharacteristic();
            Chance.Deserialize(reader);
            Agility = new CharacterBaseCharacteristic();
            Agility.Deserialize(reader);
            Intelligence = new CharacterBaseCharacteristic();
            Intelligence.Deserialize(reader);
            Range = new CharacterBaseCharacteristic();
            Range.Deserialize(reader);
            SummonableCreaturesBoost = new CharacterBaseCharacteristic();
            SummonableCreaturesBoost.Deserialize(reader);
            Reflect = new CharacterBaseCharacteristic();
            Reflect.Deserialize(reader);
            CriticalHit = new CharacterBaseCharacteristic();
            CriticalHit.Deserialize(reader);
            CriticalHitWeapon = reader.ReadVarShort();
            CriticalMiss = new CharacterBaseCharacteristic();
            CriticalMiss.Deserialize(reader);
            HealBonus = new CharacterBaseCharacteristic();
            HealBonus.Deserialize(reader);
            AllDamagesBonus = new CharacterBaseCharacteristic();
            AllDamagesBonus.Deserialize(reader);
            WeaponDamagesBonusPercent = new CharacterBaseCharacteristic();
            WeaponDamagesBonusPercent.Deserialize(reader);
            DamagesBonusPercent = new CharacterBaseCharacteristic();
            DamagesBonusPercent.Deserialize(reader);
            TrapBonus = new CharacterBaseCharacteristic();
            TrapBonus.Deserialize(reader);
            TrapBonusPercent = new CharacterBaseCharacteristic();
            TrapBonusPercent.Deserialize(reader);
            GlyphBonusPercent = new CharacterBaseCharacteristic();
            GlyphBonusPercent.Deserialize(reader);
            RuneBonusPercent = new CharacterBaseCharacteristic();
            RuneBonusPercent.Deserialize(reader);
            PermanentDamagePercent = new CharacterBaseCharacteristic();
            PermanentDamagePercent.Deserialize(reader);
            TackleBlock = new CharacterBaseCharacteristic();
            TackleBlock.Deserialize(reader);
            TackleEvade = new CharacterBaseCharacteristic();
            TackleEvade.Deserialize(reader);
            PAAttack = new CharacterBaseCharacteristic();
            PAAttack.Deserialize(reader);
            PMAttack = new CharacterBaseCharacteristic();
            PMAttack.Deserialize(reader);
            PushDamageBonus = new CharacterBaseCharacteristic();
            PushDamageBonus.Deserialize(reader);
            CriticalDamageBonus = new CharacterBaseCharacteristic();
            CriticalDamageBonus.Deserialize(reader);
            NeutralDamageBonus = new CharacterBaseCharacteristic();
            NeutralDamageBonus.Deserialize(reader);
            EarthDamageBonus = new CharacterBaseCharacteristic();
            EarthDamageBonus.Deserialize(reader);
            WaterDamageBonus = new CharacterBaseCharacteristic();
            WaterDamageBonus.Deserialize(reader);
            AirDamageBonus = new CharacterBaseCharacteristic();
            AirDamageBonus.Deserialize(reader);
            FireDamageBonus = new CharacterBaseCharacteristic();
            FireDamageBonus.Deserialize(reader);
            DodgePALostProbability = new CharacterBaseCharacteristic();
            DodgePALostProbability.Deserialize(reader);
            DodgePMLostProbability = new CharacterBaseCharacteristic();
            DodgePMLostProbability.Deserialize(reader);
            NeutralElementResistPercent = new CharacterBaseCharacteristic();
            NeutralElementResistPercent.Deserialize(reader);
            EarthElementResistPercent = new CharacterBaseCharacteristic();
            EarthElementResistPercent.Deserialize(reader);
            WaterElementResistPercent = new CharacterBaseCharacteristic();
            WaterElementResistPercent.Deserialize(reader);
            AirElementResistPercent = new CharacterBaseCharacteristic();
            AirElementResistPercent.Deserialize(reader);
            FireElementResistPercent = new CharacterBaseCharacteristic();
            FireElementResistPercent.Deserialize(reader);
            NeutralElementReduction = new CharacterBaseCharacteristic();
            NeutralElementReduction.Deserialize(reader);
            EarthElementReduction = new CharacterBaseCharacteristic();
            EarthElementReduction.Deserialize(reader);
            WaterElementReduction = new CharacterBaseCharacteristic();
            WaterElementReduction.Deserialize(reader);
            AirElementReduction = new CharacterBaseCharacteristic();
            AirElementReduction.Deserialize(reader);
            FireElementReduction = new CharacterBaseCharacteristic();
            FireElementReduction.Deserialize(reader);
            PushDamageReduction = new CharacterBaseCharacteristic();
            PushDamageReduction.Deserialize(reader);
            CriticalDamageReduction = new CharacterBaseCharacteristic();
            CriticalDamageReduction.Deserialize(reader);
            PvpNeutralElementResistPercent = new CharacterBaseCharacteristic();
            PvpNeutralElementResistPercent.Deserialize(reader);
            PvpEarthElementResistPercent = new CharacterBaseCharacteristic();
            PvpEarthElementResistPercent.Deserialize(reader);
            PvpWaterElementResistPercent = new CharacterBaseCharacteristic();
            PvpWaterElementResistPercent.Deserialize(reader);
            PvpAirElementResistPercent = new CharacterBaseCharacteristic();
            PvpAirElementResistPercent.Deserialize(reader);
            PvpFireElementResistPercent = new CharacterBaseCharacteristic();
            PvpFireElementResistPercent.Deserialize(reader);
            PvpNeutralElementReduction = new CharacterBaseCharacteristic();
            PvpNeutralElementReduction.Deserialize(reader);
            PvpEarthElementReduction = new CharacterBaseCharacteristic();
            PvpEarthElementReduction.Deserialize(reader);
            PvpWaterElementReduction = new CharacterBaseCharacteristic();
            PvpWaterElementReduction.Deserialize(reader);
            PvpAirElementReduction = new CharacterBaseCharacteristic();
            PvpAirElementReduction.Deserialize(reader);
            PvpFireElementReduction = new CharacterBaseCharacteristic();
            PvpFireElementReduction.Deserialize(reader);
            MeleeDamageDonePercent = new CharacterBaseCharacteristic();
            MeleeDamageDonePercent.Deserialize(reader);
            MeleeDamageReceivedPercent = new CharacterBaseCharacteristic();
            MeleeDamageReceivedPercent.Deserialize(reader);
            RangedDamageDonePercent = new CharacterBaseCharacteristic();
            RangedDamageDonePercent.Deserialize(reader);
            RangedDamageReceivedPercent = new CharacterBaseCharacteristic();
            RangedDamageReceivedPercent.Deserialize(reader);
            WeaponDamageDonePercent = new CharacterBaseCharacteristic();
            WeaponDamageDonePercent.Deserialize(reader);
            WeaponDamageReceivedPercent = new CharacterBaseCharacteristic();
            WeaponDamageReceivedPercent.Deserialize(reader);
            SpellDamageDonePercent = new CharacterBaseCharacteristic();
            SpellDamageDonePercent.Deserialize(reader);
            SpellDamageReceivedPercent = new CharacterBaseCharacteristic();
            SpellDamageReceivedPercent.Deserialize(reader);
            var countSpellModifications = reader.ReadShort();
            SpellModifications = new List<CharacterSpellModification>();
            for (short i = 0; i < countSpellModifications; i++)
            {
                CharacterSpellModification type = new CharacterSpellModification();
                type.Deserialize(reader);
                SpellModifications.Add(type);
            }
            ProbationTime = reader.ReadInt();
        }
    }
}