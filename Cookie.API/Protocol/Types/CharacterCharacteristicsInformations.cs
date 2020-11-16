using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterCharacteristicsInformations : NetworkType
    {
        public const ushort ProtocolId = 8;

        public override ushort TypeID => ProtocolId;

        public ulong Experience { get; set; }
        public ulong ExperienceLevelFloor { get; set; }
        public ulong ExperienceNextLevelFloor { get; set; }
        public ulong ExperienceBonusLimit { get; set; }
        public ulong Kamas { get; set; }
        public ushort StatsPoints { get; set; }
        public ushort AdditionnalPoints { get; set; }
        public ushort SpellsPoints { get; set; }
        public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort EnergyPoints { get; set; }
        public ushort MaxEnergyPoints { get; set; }
        public short ActionPointsCurrent { get; set; }
        public short MovementPointsCurrent { get; set; }
        public CharacterBaseCharacteristic Initiative { get; set; }
        public CharacterBaseCharacteristic Prospecting { get; set; }
        public CharacterBaseCharacteristic ActionPoints { get; set; }
        public CharacterBaseCharacteristic MovementPoints { get; set; }
        public CharacterBaseCharacteristic Strength { get; set; }
        public CharacterBaseCharacteristic Vitality { get; set; }
        public CharacterBaseCharacteristic Wisdom { get; set; }
        public CharacterBaseCharacteristic Chance { get; set; }
        public CharacterBaseCharacteristic Agility { get; set; }
        public CharacterBaseCharacteristic Intelligence { get; set; }
        public CharacterBaseCharacteristic Range { get; set; }
        public CharacterBaseCharacteristic SummonableCreaturesBoost { get; set; }
        public CharacterBaseCharacteristic Reflect { get; set; }
        public CharacterBaseCharacteristic CriticalHit { get; set; }
        public ushort CriticalHitWeapon { get; set; }
        public CharacterBaseCharacteristic CriticalMiss { get; set; }
        public CharacterBaseCharacteristic HealBonus { get; set; }
        public CharacterBaseCharacteristic AllDamagesBonus { get; set; }
        public CharacterBaseCharacteristic WeaponDamagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic DamagesBonusPercent { get; set; }
        public CharacterBaseCharacteristic TrapBonus { get; set; }
        public CharacterBaseCharacteristic TrapBonusPercent { get; set; }
        public CharacterBaseCharacteristic GlyphBonusPercent { get; set; }
        public CharacterBaseCharacteristic RuneBonusPercent { get; set; }
        public CharacterBaseCharacteristic PermanentDamagePercent { get; set; }
        public CharacterBaseCharacteristic TackleBlock { get; set; }
        public CharacterBaseCharacteristic TackleEvade { get; set; }
        public CharacterBaseCharacteristic PAAttack { get; set; }
        public CharacterBaseCharacteristic PMAttack { get; set; }
        public CharacterBaseCharacteristic PushDamageBonus { get; set; }
        public CharacterBaseCharacteristic CriticalDamageBonus { get; set; }
        public CharacterBaseCharacteristic NeutralDamageBonus { get; set; }
        public CharacterBaseCharacteristic EarthDamageBonus { get; set; }
        public CharacterBaseCharacteristic WaterDamageBonus { get; set; }
        public CharacterBaseCharacteristic AirDamageBonus { get; set; }
        public CharacterBaseCharacteristic FireDamageBonus { get; set; }
        public CharacterBaseCharacteristic DodgePALostProbability { get; set; }
        public CharacterBaseCharacteristic DodgePMLostProbability { get; set; }
        public CharacterBaseCharacteristic NeutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic EarthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic WaterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic AirElementResistPercent { get; set; }
        public CharacterBaseCharacteristic FireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic NeutralElementReduction { get; set; }
        public CharacterBaseCharacteristic EarthElementReduction { get; set; }
        public CharacterBaseCharacteristic WaterElementReduction { get; set; }
        public CharacterBaseCharacteristic AirElementReduction { get; set; }
        public CharacterBaseCharacteristic FireElementReduction { get; set; }
        public CharacterBaseCharacteristic PushDamageReduction { get; set; }
        public CharacterBaseCharacteristic CriticalDamageReduction { get; set; }
        public CharacterBaseCharacteristic PvpNeutralElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpEarthElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpWaterElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpAirElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpFireElementResistPercent { get; set; }
        public CharacterBaseCharacteristic PvpNeutralElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpEarthElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpWaterElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpAirElementReduction { get; set; }
        public CharacterBaseCharacteristic PvpFireElementReduction { get; set; }
        public CharacterBaseCharacteristic MeleeDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic MeleeDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic RangedDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic RangedDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic WeaponDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic WeaponDamageReceivedPercent { get; set; }
        public CharacterBaseCharacteristic SpellDamageDonePercent { get; set; }
        public CharacterBaseCharacteristic SpellDamageReceivedPercent { get; set; }
        public List<CharacterSpellModification> SpellModifications { get; set; }
        public int ProbationTime { get; set; }
        public CharacterCharacteristicsInformations() { }

        public CharacterCharacteristicsInformations( ulong Experience, ulong ExperienceLevelFloor, ulong ExperienceNextLevelFloor, ulong ExperienceBonusLimit, ulong Kamas, ushort StatsPoints, ushort AdditionnalPoints, ushort SpellsPoints, ActorExtendedAlignmentInformations AlignmentInfos, uint LifePoints, uint MaxLifePoints, ushort EnergyPoints, ushort MaxEnergyPoints, short ActionPointsCurrent, short MovementPointsCurrent, CharacterBaseCharacteristic Initiative, CharacterBaseCharacteristic Prospecting, CharacterBaseCharacteristic ActionPoints, CharacterBaseCharacteristic MovementPoints, CharacterBaseCharacteristic Strength, CharacterBaseCharacteristic Vitality, CharacterBaseCharacteristic Wisdom, CharacterBaseCharacteristic Chance, CharacterBaseCharacteristic Agility, CharacterBaseCharacteristic Intelligence, CharacterBaseCharacteristic Range, CharacterBaseCharacteristic SummonableCreaturesBoost, CharacterBaseCharacteristic Reflect, CharacterBaseCharacteristic CriticalHit, ushort CriticalHitWeapon, CharacterBaseCharacteristic CriticalMiss, CharacterBaseCharacteristic HealBonus, CharacterBaseCharacteristic AllDamagesBonus, CharacterBaseCharacteristic WeaponDamagesBonusPercent, CharacterBaseCharacteristic DamagesBonusPercent, CharacterBaseCharacteristic TrapBonus, CharacterBaseCharacteristic TrapBonusPercent, CharacterBaseCharacteristic GlyphBonusPercent, CharacterBaseCharacteristic RuneBonusPercent, CharacterBaseCharacteristic PermanentDamagePercent, CharacterBaseCharacteristic TackleBlock, CharacterBaseCharacteristic TackleEvade, CharacterBaseCharacteristic PAAttack, CharacterBaseCharacteristic PMAttack, CharacterBaseCharacteristic PushDamageBonus, CharacterBaseCharacteristic CriticalDamageBonus, CharacterBaseCharacteristic NeutralDamageBonus, CharacterBaseCharacteristic EarthDamageBonus, CharacterBaseCharacteristic WaterDamageBonus, CharacterBaseCharacteristic AirDamageBonus, CharacterBaseCharacteristic FireDamageBonus, CharacterBaseCharacteristic DodgePALostProbability, CharacterBaseCharacteristic DodgePMLostProbability, CharacterBaseCharacteristic NeutralElementResistPercent, CharacterBaseCharacteristic EarthElementResistPercent, CharacterBaseCharacteristic WaterElementResistPercent, CharacterBaseCharacteristic AirElementResistPercent, CharacterBaseCharacteristic FireElementResistPercent, CharacterBaseCharacteristic NeutralElementReduction, CharacterBaseCharacteristic EarthElementReduction, CharacterBaseCharacteristic WaterElementReduction, CharacterBaseCharacteristic AirElementReduction, CharacterBaseCharacteristic FireElementReduction, CharacterBaseCharacteristic PushDamageReduction, CharacterBaseCharacteristic CriticalDamageReduction, CharacterBaseCharacteristic PvpNeutralElementResistPercent, CharacterBaseCharacteristic PvpEarthElementResistPercent, CharacterBaseCharacteristic PvpWaterElementResistPercent, CharacterBaseCharacteristic PvpAirElementResistPercent, CharacterBaseCharacteristic PvpFireElementResistPercent, CharacterBaseCharacteristic PvpNeutralElementReduction, CharacterBaseCharacteristic PvpEarthElementReduction, CharacterBaseCharacteristic PvpWaterElementReduction, CharacterBaseCharacteristic PvpAirElementReduction, CharacterBaseCharacteristic PvpFireElementReduction, CharacterBaseCharacteristic MeleeDamageDonePercent, CharacterBaseCharacteristic MeleeDamageReceivedPercent, CharacterBaseCharacteristic RangedDamageDonePercent, CharacterBaseCharacteristic RangedDamageReceivedPercent, CharacterBaseCharacteristic WeaponDamageDonePercent, CharacterBaseCharacteristic WeaponDamageReceivedPercent, CharacterBaseCharacteristic SpellDamageDonePercent, CharacterBaseCharacteristic SpellDamageReceivedPercent, List<CharacterSpellModification> SpellModifications, int ProbationTime ){
            this.Experience = Experience;
            this.ExperienceLevelFloor = ExperienceLevelFloor;
            this.ExperienceNextLevelFloor = ExperienceNextLevelFloor;
            this.ExperienceBonusLimit = ExperienceBonusLimit;
            this.Kamas = Kamas;
            this.StatsPoints = StatsPoints;
            this.AdditionnalPoints = AdditionnalPoints;
            this.SpellsPoints = SpellsPoints;
            this.AlignmentInfos = AlignmentInfos;
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
            this.EnergyPoints = EnergyPoints;
            this.MaxEnergyPoints = MaxEnergyPoints;
            this.ActionPointsCurrent = ActionPointsCurrent;
            this.MovementPointsCurrent = MovementPointsCurrent;
            this.Initiative = Initiative;
            this.Prospecting = Prospecting;
            this.ActionPoints = ActionPoints;
            this.MovementPoints = MovementPoints;
            this.Strength = Strength;
            this.Vitality = Vitality;
            this.Wisdom = Wisdom;
            this.Chance = Chance;
            this.Agility = Agility;
            this.Intelligence = Intelligence;
            this.Range = Range;
            this.SummonableCreaturesBoost = SummonableCreaturesBoost;
            this.Reflect = Reflect;
            this.CriticalHit = CriticalHit;
            this.CriticalHitWeapon = CriticalHitWeapon;
            this.CriticalMiss = CriticalMiss;
            this.HealBonus = HealBonus;
            this.AllDamagesBonus = AllDamagesBonus;
            this.WeaponDamagesBonusPercent = WeaponDamagesBonusPercent;
            this.DamagesBonusPercent = DamagesBonusPercent;
            this.TrapBonus = TrapBonus;
            this.TrapBonusPercent = TrapBonusPercent;
            this.GlyphBonusPercent = GlyphBonusPercent;
            this.RuneBonusPercent = RuneBonusPercent;
            this.PermanentDamagePercent = PermanentDamagePercent;
            this.TackleBlock = TackleBlock;
            this.TackleEvade = TackleEvade;
            this.PAAttack = PAAttack;
            this.PMAttack = PMAttack;
            this.PushDamageBonus = PushDamageBonus;
            this.CriticalDamageBonus = CriticalDamageBonus;
            this.NeutralDamageBonus = NeutralDamageBonus;
            this.EarthDamageBonus = EarthDamageBonus;
            this.WaterDamageBonus = WaterDamageBonus;
            this.AirDamageBonus = AirDamageBonus;
            this.FireDamageBonus = FireDamageBonus;
            this.DodgePALostProbability = DodgePALostProbability;
            this.DodgePMLostProbability = DodgePMLostProbability;
            this.NeutralElementResistPercent = NeutralElementResistPercent;
            this.EarthElementResistPercent = EarthElementResistPercent;
            this.WaterElementResistPercent = WaterElementResistPercent;
            this.AirElementResistPercent = AirElementResistPercent;
            this.FireElementResistPercent = FireElementResistPercent;
            this.NeutralElementReduction = NeutralElementReduction;
            this.EarthElementReduction = EarthElementReduction;
            this.WaterElementReduction = WaterElementReduction;
            this.AirElementReduction = AirElementReduction;
            this.FireElementReduction = FireElementReduction;
            this.PushDamageReduction = PushDamageReduction;
            this.CriticalDamageReduction = CriticalDamageReduction;
            this.PvpNeutralElementResistPercent = PvpNeutralElementResistPercent;
            this.PvpEarthElementResistPercent = PvpEarthElementResistPercent;
            this.PvpWaterElementResistPercent = PvpWaterElementResistPercent;
            this.PvpAirElementResistPercent = PvpAirElementResistPercent;
            this.PvpFireElementResistPercent = PvpFireElementResistPercent;
            this.PvpNeutralElementReduction = PvpNeutralElementReduction;
            this.PvpEarthElementReduction = PvpEarthElementReduction;
            this.PvpWaterElementReduction = PvpWaterElementReduction;
            this.PvpAirElementReduction = PvpAirElementReduction;
            this.PvpFireElementReduction = PvpFireElementReduction;
            this.MeleeDamageDonePercent = MeleeDamageDonePercent;
            this.MeleeDamageReceivedPercent = MeleeDamageReceivedPercent;
            this.RangedDamageDonePercent = RangedDamageDonePercent;
            this.RangedDamageReceivedPercent = RangedDamageReceivedPercent;
            this.WeaponDamageDonePercent = WeaponDamageDonePercent;
            this.WeaponDamageReceivedPercent = WeaponDamageReceivedPercent;
            this.SpellDamageDonePercent = SpellDamageDonePercent;
            this.SpellDamageReceivedPercent = SpellDamageReceivedPercent;
            this.SpellModifications = SpellModifications;
            this.ProbationTime = ProbationTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhLong(ExperienceLevelFloor);
            writer.WriteVarUhLong(ExperienceNextLevelFloor);
            writer.WriteVarUhLong(ExperienceBonusLimit);
            writer.WriteVarUhLong(Kamas);
            writer.WriteVarUhShort(StatsPoints);
            writer.WriteVarUhShort(AdditionnalPoints);
            writer.WriteVarUhShort(SpellsPoints);
            AlignmentInfos.Serialize(writer);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(EnergyPoints);
            writer.WriteVarUhShort(MaxEnergyPoints);
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
            writer.WriteVarUhShort(CriticalHitWeapon);
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
			writer.WriteShort((short)SpellModifications.Count);
			foreach (var x in SpellModifications)
			{
				x.Serialize(writer);
			}
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Experience = reader.ReadVarUhLong();
            ExperienceLevelFloor = reader.ReadVarUhLong();
            ExperienceNextLevelFloor = reader.ReadVarUhLong();
            ExperienceBonusLimit = reader.ReadVarUhLong();
            Kamas = reader.ReadVarUhLong();
            StatsPoints = reader.ReadVarUhShort();
            AdditionnalPoints = reader.ReadVarUhShort();
            SpellsPoints = reader.ReadVarUhShort();
            AlignmentInfos = new ActorExtendedAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            EnergyPoints = reader.ReadVarUhShort();
            MaxEnergyPoints = reader.ReadVarUhShort();
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
            CriticalHitWeapon = reader.ReadVarUhShort();
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
            var SpellModificationsCount = reader.ReadShort();
            SpellModifications = new List<CharacterSpellModification>();
            for (var i = 0; i < SpellModificationsCount; i++)
            {
                var objectToAdd = new CharacterSpellModification();
                objectToAdd.Deserialize(reader);
                SpellModifications.Add(objectToAdd);
            }
            ProbationTime = reader.ReadInt();
        }
    }
}
