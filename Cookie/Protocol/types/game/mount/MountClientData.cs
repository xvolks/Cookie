using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class MountClientData : NetworkType
    {
        public const short ProtocolId = 178;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;
        public bool IsRideable = false;
        public bool IsWild = false;
        public bool IsFecondationReady = false;
        public bool UseHarnessColors = false;
        public double Id_ = 0;
        public int Model = 0;
        public List<int> Ancestor;
        public List<int> Behaviors;
        public string Name;
        public int OwnerId = 0;
        public long Experience = 0;
        public long ExperienceForLevel = 0;
        public double ExperienceForNextLevel = 0;
        public byte Level = 0;
        public int MaxPods = 0;
        public int Stamina = 0;
        public int StaminaMax = 0;
        public int Maturity = 0;
        public int MaturityForAdult = 0;
        public int Energy = 0;
        public int EnergyMax = 0;
        public int Serenity = 0;
        public int AggressivityMax = 0;
        public int SerenityMax = 0;
        public int Love = 0;
        public int LoveMax = 0;
        public int FecondationTime = 0;
        public int BoostLimiter = 0;
        public double BoostMax = 0;
        public int ReproductionCount = 0;
        public int ReproductionCountMax = 0;
        public short HarnessGID = 0;
        public List<ObjectEffectInteger> EffectList;

        public MountClientData()
        {
        }

        public MountClientData(
            bool sex,
            bool isRideable,
            bool isWild,
            bool isFecondationReady,
            bool useHarnessColors,
            double id_,
            int model,
            List<int> ancestor,
            List<int> behaviors,
            string name,
            int ownerId,
            long experience,
            long experienceForLevel,
            double experienceForNextLevel,
            byte level,
            int maxPods,
            int stamina,
            int staminaMax,
            int maturity,
            int maturityForAdult,
            int energy,
            int energyMax,
            int serenity,
            int aggressivityMax,
            int serenityMax,
            int love,
            int loveMax,
            int fecondationTime,
            int boostLimiter,
            double boostMax,
            int reproductionCount,
            int reproductionCountMax,
            short harnessGID,
            List<ObjectEffectInteger> effectList
        )
        {
            Sex = sex;
            IsRideable = isRideable;
            IsWild = isWild;
            IsFecondationReady = isFecondationReady;
            UseHarnessColors = useHarnessColors;
            Id_ = id_;
            Model = model;
            Ancestor = ancestor;
            Behaviors = behaviors;
            Name = name;
            OwnerId = ownerId;
            Experience = experience;
            ExperienceForLevel = experienceForLevel;
            ExperienceForNextLevel = experienceForNextLevel;
            Level = level;
            MaxPods = maxPods;
            Stamina = stamina;
            StaminaMax = staminaMax;
            Maturity = maturity;
            MaturityForAdult = maturityForAdult;
            Energy = energy;
            EnergyMax = energyMax;
            Serenity = serenity;
            AggressivityMax = aggressivityMax;
            SerenityMax = serenityMax;
            Love = love;
            LoveMax = loveMax;
            FecondationTime = fecondationTime;
            BoostLimiter = boostLimiter;
            BoostMax = boostMax;
            ReproductionCount = reproductionCount;
            ReproductionCountMax = reproductionCountMax;
            HarnessGID = harnessGID;
            EffectList = effectList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Sex);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsRideable);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, IsWild);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, IsFecondationReady);
            box0 = BooleanByteWrapper.SetFlag(box0, 5, UseHarnessColors);
            writer.WriteByte(box0);
            writer.WriteDouble(Id_);
            writer.WriteVarInt(Model);
            writer.WriteShort((short)Ancestor.Count());
            foreach (var current in Ancestor)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort((short)Behaviors.Count());
            foreach (var current in Behaviors)
            {
                writer.WriteInt(current);
            }
            writer.WriteUTF(Name);
            writer.WriteInt(OwnerId);
            writer.WriteVarLong(Experience);
            writer.WriteVarLong(ExperienceForLevel);
            writer.WriteDouble(ExperienceForNextLevel);
            writer.WriteByte(Level);
            writer.WriteVarInt(MaxPods);
            writer.WriteVarInt(Stamina);
            writer.WriteVarInt(StaminaMax);
            writer.WriteVarInt(Maturity);
            writer.WriteVarInt(MaturityForAdult);
            writer.WriteVarInt(Energy);
            writer.WriteVarInt(EnergyMax);
            writer.WriteInt(Serenity);
            writer.WriteInt(AggressivityMax);
            writer.WriteVarInt(SerenityMax);
            writer.WriteVarInt(Love);
            writer.WriteVarInt(LoveMax);
            writer.WriteInt(FecondationTime);
            writer.WriteInt(BoostLimiter);
            writer.WriteDouble(BoostMax);
            writer.WriteInt(ReproductionCount);
            writer.WriteVarInt(ReproductionCountMax);
            writer.WriteVarShort(HarnessGID);
            writer.WriteShort((short)EffectList.Count());
            foreach (var current in EffectList)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(box0, 1);
            IsRideable = BooleanByteWrapper.GetFlag(box0, 2);
            IsWild = BooleanByteWrapper.GetFlag(box0, 3);
            IsFecondationReady = BooleanByteWrapper.GetFlag(box0, 4);
            UseHarnessColors = BooleanByteWrapper.GetFlag(box0, 5);
            Id_ = reader.ReadDouble();
            Model = reader.ReadVarInt();
            var countAncestor = reader.ReadShort();
            Ancestor = new List<int>();
            for (short i = 0; i < countAncestor; i++)
            {
                Ancestor.Add(reader.ReadInt());
            }
            var countBehaviors = reader.ReadShort();
            Behaviors = new List<int>();
            for (short i = 0; i < countBehaviors; i++)
            {
                Behaviors.Add(reader.ReadInt());
            }
            Name = reader.ReadUTF();
            OwnerId = reader.ReadInt();
            Experience = reader.ReadVarLong();
            ExperienceForLevel = reader.ReadVarLong();
            ExperienceForNextLevel = reader.ReadDouble();
            Level = reader.ReadByte();
            MaxPods = reader.ReadVarInt();
            Stamina = reader.ReadVarInt();
            StaminaMax = reader.ReadVarInt();
            Maturity = reader.ReadVarInt();
            MaturityForAdult = reader.ReadVarInt();
            Energy = reader.ReadVarInt();
            EnergyMax = reader.ReadVarInt();
            Serenity = reader.ReadInt();
            AggressivityMax = reader.ReadInt();
            SerenityMax = reader.ReadVarInt();
            Love = reader.ReadVarInt();
            LoveMax = reader.ReadVarInt();
            FecondationTime = reader.ReadInt();
            BoostLimiter = reader.ReadInt();
            BoostMax = reader.ReadDouble();
            ReproductionCount = reader.ReadInt();
            ReproductionCountMax = reader.ReadVarInt();
            HarnessGID = reader.ReadVarShort();
            var countEffectList = reader.ReadShort();
            EffectList = new List<ObjectEffectInteger>();
            for (short i = 0; i < countEffectList; i++)
            {
                ObjectEffectInteger type = new ObjectEffectInteger();
                type.Deserialize(reader);
                EffectList.Add(type);
            }
        }
    }
}