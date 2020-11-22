using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MountClientData : NetworkType
    {
        public const ushort ProtocolId = 178;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public bool IsRideable { get; set; }
        public bool IsWild { get; set; }
        public bool IsFecondationReady { get; set; }
        public bool UseHarnessColors { get; set; }
        public double Id { get; set; }
        public uint Model { get; set; }
        public List<int> Ancestor { get; set; }
        public List<int> Behaviors { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public ulong Experience { get; set; }
        public ulong ExperienceForLevel { get; set; }
        public double ExperienceForNextLevel { get; set; }
        public sbyte Level { get; set; }
        public uint MaxPods { get; set; }
        public uint Stamina { get; set; }
        public uint StaminaMax { get; set; }
        public uint Maturity { get; set; }
        public uint MaturityForAdult { get; set; }
        public uint Energy { get; set; }
        public uint EnergyMax { get; set; }
        public int Serenity { get; set; }
        public int AggressivityMax { get; set; }
        public uint SerenityMax { get; set; }
        public uint Love { get; set; }
        public uint LoveMax { get; set; }
        public int FecondationTime { get; set; }
        public int BoostLimiter { get; set; }
        public double BoostMax { get; set; }
        public int ReproductionCount { get; set; }
        public uint ReproductionCountMax { get; set; }
        public ushort HarnessGID { get; set; }
        public List<ObjectEffectInteger> EffectList { get; set; }
        public MountClientData() { }

        public MountClientData( bool Sex, bool IsRideable, bool IsWild, bool IsFecondationReady, bool UseHarnessColors, double Id, uint Model, List<int> Ancestor, List<int> Behaviors, string Name, int OwnerId, ulong Experience, ulong ExperienceForLevel, double ExperienceForNextLevel, sbyte Level, uint MaxPods, uint Stamina, uint StaminaMax, uint Maturity, uint MaturityForAdult, uint Energy, uint EnergyMax, int Serenity, int AggressivityMax, uint SerenityMax, uint Love, uint LoveMax, int FecondationTime, int BoostLimiter, double BoostMax, int ReproductionCount, uint ReproductionCountMax, ushort HarnessGID, List<ObjectEffectInteger> EffectList ){
            this.Sex = Sex;
            this.IsRideable = IsRideable;
            this.IsWild = IsWild;
            this.IsFecondationReady = IsFecondationReady;
            this.UseHarnessColors = UseHarnessColors;
            this.Id = Id;
            this.Model = Model;
            this.Ancestor = Ancestor;
            this.Behaviors = Behaviors;
            this.Name = Name;
            this.OwnerId = OwnerId;
            this.Experience = Experience;
            this.ExperienceForLevel = ExperienceForLevel;
            this.ExperienceForNextLevel = ExperienceForNextLevel;
            this.Level = Level;
            this.MaxPods = MaxPods;
            this.Stamina = Stamina;
            this.StaminaMax = StaminaMax;
            this.Maturity = Maturity;
            this.MaturityForAdult = MaturityForAdult;
            this.Energy = Energy;
            this.EnergyMax = EnergyMax;
            this.Serenity = Serenity;
            this.AggressivityMax = AggressivityMax;
            this.SerenityMax = SerenityMax;
            this.Love = Love;
            this.LoveMax = LoveMax;
            this.FecondationTime = FecondationTime;
            this.BoostLimiter = BoostLimiter;
            this.BoostMax = BoostMax;
            this.ReproductionCount = ReproductionCount;
            this.ReproductionCountMax = ReproductionCountMax;
            this.HarnessGID = HarnessGID;
            this.EffectList = EffectList;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsRideable);
			flag = BooleanByteWrapper.SetFlag(2, flag, IsWild);
			flag = BooleanByteWrapper.SetFlag(3, flag, IsFecondationReady);
			flag = BooleanByteWrapper.SetFlag(4, flag, UseHarnessColors);
			writer.WriteByte(flag);
            writer.WriteDouble(Id);
            writer.WriteVarUhInt(Model);
			writer.WriteShort((short)Ancestor.Count);
			foreach (var x in Ancestor)
			{
				writer.WriteInt(x);
			}
			writer.WriteShort((short)Behaviors.Count);
			foreach (var x in Behaviors)
			{
				writer.WriteInt(x);
			}
            writer.WriteUTF(Name);
            writer.WriteInt(OwnerId);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhLong(ExperienceForLevel);
            writer.WriteDouble(ExperienceForNextLevel);
            writer.WriteSByte(Level);
            writer.WriteVarUhInt(MaxPods);
            writer.WriteVarUhInt(Stamina);
            writer.WriteVarUhInt(StaminaMax);
            writer.WriteVarUhInt(Maturity);
            writer.WriteVarUhInt(MaturityForAdult);
            writer.WriteVarUhInt(Energy);
            writer.WriteVarUhInt(EnergyMax);
            writer.WriteInt(Serenity);
            writer.WriteInt(AggressivityMax);
            writer.WriteVarUhInt(SerenityMax);
            writer.WriteVarUhInt(Love);
            writer.WriteVarUhInt(LoveMax);
            writer.WriteInt(FecondationTime);
            writer.WriteInt(BoostLimiter);
            writer.WriteDouble(BoostMax);
            writer.WriteInt(ReproductionCount);
            writer.WriteVarUhInt(ReproductionCountMax);
            writer.WriteVarUhShort(HarnessGID);
			writer.WriteShort((short)EffectList.Count);
			foreach (var x in EffectList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Sex = BooleanByteWrapper.GetFlag(flag, 0);
			IsRideable = BooleanByteWrapper.GetFlag(flag, 1);
			IsWild = BooleanByteWrapper.GetFlag(flag, 2);
			IsFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
			UseHarnessColors = BooleanByteWrapper.GetFlag(flag, 4);
            Id = reader.ReadDouble();
            Model = reader.ReadVarUhInt();
            var AncestorCount = reader.ReadShort();
            Ancestor = new List<int>();
            for (var i = 0; i < AncestorCount; i++)
            {
                Ancestor.Add(reader.ReadInt());
            }
            var BehaviorsCount = reader.ReadShort();
            Behaviors = new List<int>();
            for (var i = 0; i < BehaviorsCount; i++)
            {
                Behaviors.Add(reader.ReadInt());
            }
            Name = reader.ReadUTF();
            OwnerId = reader.ReadInt();
            Experience = reader.ReadVarUhLong();
            ExperienceForLevel = reader.ReadVarUhLong();
            ExperienceForNextLevel = reader.ReadDouble();
            Level = reader.ReadSByte();
            MaxPods = reader.ReadVarUhInt();
            Stamina = reader.ReadVarUhInt();
            StaminaMax = reader.ReadVarUhInt();
            Maturity = reader.ReadVarUhInt();
            MaturityForAdult = reader.ReadVarUhInt();
            Energy = reader.ReadVarUhInt();
            EnergyMax = reader.ReadVarUhInt();
            Serenity = reader.ReadInt();
            AggressivityMax = reader.ReadInt();
            SerenityMax = reader.ReadVarUhInt();
            Love = reader.ReadVarUhInt();
            LoveMax = reader.ReadVarUhInt();
            FecondationTime = reader.ReadInt();
            BoostLimiter = reader.ReadInt();
            BoostMax = reader.ReadDouble();
            ReproductionCount = reader.ReadInt();
            ReproductionCountMax = reader.ReadVarUhInt();
            HarnessGID = reader.ReadVarUhShort();
            var EffectListCount = reader.ReadShort();
            EffectList = new List<ObjectEffectInteger>();
            for (var i = 0; i < EffectListCount; i++)
            {
                var objectToAdd = new ObjectEffectInteger();
                objectToAdd.Deserialize(reader);
                EffectList.Add(objectToAdd);
            }
        }
    }
}
