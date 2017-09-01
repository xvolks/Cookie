using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Mount
{
    public class MountClientData : NetworkType
    {
        public const ushort ProtocolId = 178;

        public MountClientData(bool sex, bool isRideable, bool isWild, bool isFecondationReady, bool useHarnessColors,
            double objectId, uint model, List<int> ancestor, List<int> behaviors, string name, int ownerId,
            ulong experience, ulong experienceForLevel, double experienceForNextLevel, byte level, uint maxPods,
            uint stamina, uint staminaMax, uint maturity, uint maturityForAdult, uint energy, uint energyMax,
            int serenity, int aggressivityMax, uint serenityMax, uint love, uint loveMax, int fecondationTime,
            int boostLimiter, double boostMax, int reproductionCount, uint reproductionCountMax, ushort harnessGID,
            List<ObjectEffectInteger> effectList)
        {
            Sex = sex;
            IsRideable = isRideable;
            IsWild = isWild;
            IsFecondationReady = isFecondationReady;
            UseHarnessColors = useHarnessColors;
            ObjectId = objectId;
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

        public MountClientData()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool Sex { get; set; }
        public bool IsRideable { get; set; }
        public bool IsWild { get; set; }
        public bool IsFecondationReady { get; set; }
        public bool UseHarnessColors { get; set; }
        public double ObjectId { get; set; }
        public uint Model { get; set; }
        public List<int> Ancestor { get; set; }
        public List<int> Behaviors { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public ulong Experience { get; set; }
        public ulong ExperienceForLevel { get; set; }
        public double ExperienceForNextLevel { get; set; }
        public byte Level { get; set; }
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

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
            flag = BooleanByteWrapper.SetFlag(1, flag, IsRideable);
            flag = BooleanByteWrapper.SetFlag(2, flag, IsWild);
            flag = BooleanByteWrapper.SetFlag(3, flag, IsFecondationReady);
            flag = BooleanByteWrapper.SetFlag(4, flag, UseHarnessColors);
            writer.WriteByte(flag);
            writer.WriteDouble(ObjectId);
            writer.WriteVarUhInt(Model);
            writer.WriteShort((short) Ancestor.Count);
            for (var ancestorIndex = 0; ancestorIndex < Ancestor.Count; ancestorIndex++)
                writer.WriteInt(Ancestor[ancestorIndex]);
            writer.WriteShort((short) Behaviors.Count);
            for (var behaviorsIndex = 0; behaviorsIndex < Behaviors.Count; behaviorsIndex++)
                writer.WriteInt(Behaviors[behaviorsIndex]);
            writer.WriteUTF(Name);
            writer.WriteInt(OwnerId);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhLong(ExperienceForLevel);
            writer.WriteDouble(ExperienceForNextLevel);
            writer.WriteByte(Level);
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
            writer.WriteShort((short) EffectList.Count);
            for (var effectListIndex = 0; effectListIndex < EffectList.Count; effectListIndex++)
            {
                var objectToSend = EffectList[effectListIndex];
                objectToSend.Serialize(writer);
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
            ObjectId = reader.ReadDouble();
            Model = reader.ReadVarUhInt();
            var ancestorCount = reader.ReadUShort();
            Ancestor = new List<int>();
            for (var ancestorIndex = 0; ancestorIndex < ancestorCount; ancestorIndex++)
                Ancestor.Add(reader.ReadInt());
            var behaviorsCount = reader.ReadUShort();
            Behaviors = new List<int>();
            for (var behaviorsIndex = 0; behaviorsIndex < behaviorsCount; behaviorsIndex++)
                Behaviors.Add(reader.ReadInt());
            Name = reader.ReadUTF();
            OwnerId = reader.ReadInt();
            Experience = reader.ReadVarUhLong();
            ExperienceForLevel = reader.ReadVarUhLong();
            ExperienceForNextLevel = reader.ReadDouble();
            Level = reader.ReadByte();
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
            var effectListCount = reader.ReadUShort();
            EffectList = new List<ObjectEffectInteger>();
            for (var effectListIndex = 0; effectListIndex < effectListCount; effectListIndex++)
            {
                var objectToAdd = new ObjectEffectInteger();
                objectToAdd.Deserialize(reader);
                EffectList.Add(objectToAdd);
            }
        }
    }
}