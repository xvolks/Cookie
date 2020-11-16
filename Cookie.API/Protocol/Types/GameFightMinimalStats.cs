using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightMinimalStats : NetworkType
    {
        public const ushort ProtocolId = 31;

        public override ushort TypeID => ProtocolId;

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public uint BaseMaxLifePoints { get; set; }
        public uint PermanentDamagePercent { get; set; }
        public uint ShieldPoints { get; set; }
        public short ActionPoints { get; set; }
        public short MaxActionPoints { get; set; }
        public short MovementPoints { get; set; }
        public short MaxMovementPoints { get; set; }
        public double Summoner { get; set; }
        public bool Summoned { get; set; }
        public short NeutralElementResistPercent { get; set; }
        public short EarthElementResistPercent { get; set; }
        public short WaterElementResistPercent { get; set; }
        public short AirElementResistPercent { get; set; }
        public short FireElementResistPercent { get; set; }
        public short NeutralElementReduction { get; set; }
        public short EarthElementReduction { get; set; }
        public short WaterElementReduction { get; set; }
        public short AirElementReduction { get; set; }
        public short FireElementReduction { get; set; }
        public short CriticalDamageFixedResist { get; set; }
        public short PushDamageFixedResist { get; set; }
        public short PvpNeutralElementResistPercent { get; set; }
        public short PvpEarthElementResistPercent { get; set; }
        public short PvpWaterElementResistPercent { get; set; }
        public short PvpAirElementResistPercent { get; set; }
        public short PvpFireElementResistPercent { get; set; }
        public short PvpNeutralElementReduction { get; set; }
        public short PvpEarthElementReduction { get; set; }
        public short PvpWaterElementReduction { get; set; }
        public short PvpAirElementReduction { get; set; }
        public short PvpFireElementReduction { get; set; }
        public ushort DodgePALostProbability { get; set; }
        public ushort DodgePMLostProbability { get; set; }
        public short TackleBlock { get; set; }
        public short TackleEvade { get; set; }
        public short FixedDamageReflection { get; set; }
        public sbyte InvisibilityState { get; set; }
        public ushort MeleeDamageReceivedPercent { get; set; }
        public ushort RangedDamageReceivedPercent { get; set; }
        public ushort WeaponDamageReceivedPercent { get; set; }
        public ushort SpellDamageReceivedPercent { get; set; }
        public GameFightMinimalStats() { }

        public GameFightMinimalStats( uint LifePoints, uint MaxLifePoints, uint BaseMaxLifePoints, uint PermanentDamagePercent, uint ShieldPoints, short ActionPoints, short MaxActionPoints, short MovementPoints, short MaxMovementPoints, double Summoner, bool Summoned, short NeutralElementResistPercent, short EarthElementResistPercent, short WaterElementResistPercent, short AirElementResistPercent, short FireElementResistPercent, short NeutralElementReduction, short EarthElementReduction, short WaterElementReduction, short AirElementReduction, short FireElementReduction, short CriticalDamageFixedResist, short PushDamageFixedResist, short PvpNeutralElementResistPercent, short PvpEarthElementResistPercent, short PvpWaterElementResistPercent, short PvpAirElementResistPercent, short PvpFireElementResistPercent, short PvpNeutralElementReduction, short PvpEarthElementReduction, short PvpWaterElementReduction, short PvpAirElementReduction, short PvpFireElementReduction, ushort DodgePALostProbability, ushort DodgePMLostProbability, short TackleBlock, short TackleEvade, short FixedDamageReflection, sbyte InvisibilityState, ushort MeleeDamageReceivedPercent, ushort RangedDamageReceivedPercent, ushort WeaponDamageReceivedPercent, ushort SpellDamageReceivedPercent ){
            this.LifePoints = LifePoints;
            this.MaxLifePoints = MaxLifePoints;
            this.BaseMaxLifePoints = BaseMaxLifePoints;
            this.PermanentDamagePercent = PermanentDamagePercent;
            this.ShieldPoints = ShieldPoints;
            this.ActionPoints = ActionPoints;
            this.MaxActionPoints = MaxActionPoints;
            this.MovementPoints = MovementPoints;
            this.MaxMovementPoints = MaxMovementPoints;
            this.Summoner = Summoner;
            this.Summoned = Summoned;
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
            this.CriticalDamageFixedResist = CriticalDamageFixedResist;
            this.PushDamageFixedResist = PushDamageFixedResist;
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
            this.DodgePALostProbability = DodgePALostProbability;
            this.DodgePMLostProbability = DodgePMLostProbability;
            this.TackleBlock = TackleBlock;
            this.TackleEvade = TackleEvade;
            this.FixedDamageReflection = FixedDamageReflection;
            this.InvisibilityState = InvisibilityState;
            this.MeleeDamageReceivedPercent = MeleeDamageReceivedPercent;
            this.RangedDamageReceivedPercent = RangedDamageReceivedPercent;
            this.WeaponDamageReceivedPercent = WeaponDamageReceivedPercent;
            this.SpellDamageReceivedPercent = SpellDamageReceivedPercent;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhInt(BaseMaxLifePoints);
            writer.WriteVarUhInt(PermanentDamagePercent);
            writer.WriteVarUhInt(ShieldPoints);
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
            writer.WriteVarUhShort(DodgePALostProbability);
            writer.WriteVarUhShort(DodgePMLostProbability);
            writer.WriteVarShort(TackleBlock);
            writer.WriteVarShort(TackleEvade);
            writer.WriteVarShort(FixedDamageReflection);
            writer.WriteSByte(InvisibilityState);
            writer.WriteVarUhShort(MeleeDamageReceivedPercent);
            writer.WriteVarUhShort(RangedDamageReceivedPercent);
            writer.WriteVarUhShort(WeaponDamageReceivedPercent);
            writer.WriteVarUhShort(SpellDamageReceivedPercent);
        }

        public override void Deserialize(IDataReader reader)
        {
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            BaseMaxLifePoints = reader.ReadVarUhInt();
            PermanentDamagePercent = reader.ReadVarUhInt();
            ShieldPoints = reader.ReadVarUhInt();
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
            DodgePALostProbability = reader.ReadVarUhShort();
            DodgePMLostProbability = reader.ReadVarUhShort();
            TackleBlock = reader.ReadVarShort();
            TackleEvade = reader.ReadVarShort();
            FixedDamageReflection = reader.ReadVarShort();
            InvisibilityState = reader.ReadSByte();
            MeleeDamageReceivedPercent = reader.ReadVarUhShort();
            RangedDamageReceivedPercent = reader.ReadVarUhShort();
            WeaponDamageReceivedPercent = reader.ReadVarUhShort();
            SpellDamageReceivedPercent = reader.ReadVarUhShort();
        }
    }
}
