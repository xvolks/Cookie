using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectMount : ObjectEffect
    {
        public new const short ProtocolId = 179;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;
        public bool IsRideable = false;
        public bool IsFeconded = false;
        public bool IsFecondationReady = false;
        public long Id_ = 0;
        public long ExpirationDate = 0;
        public int Model = 0;
        public string Name;
        public string Owner;
        public byte Level = 0;
        public int ReproductionCount = 0;
        public int ReproductionCountMax = 0;
        public List<ObjectEffectInteger> Effects;
        public List<int> Capacities;

        public ObjectEffectMount(): base()
        {
        }

        public ObjectEffectMount(
            short actionId,
            bool sex,
            bool isRideable,
            bool isFeconded,
            bool isFecondationReady,
            long id_,
            long expirationDate,
            int model,
            string name,
            string owner,
            byte level,
            int reproductionCount,
            int reproductionCountMax,
            List<ObjectEffectInteger> effects,
            List<int> capacities
        ): base(
            actionId
        )
        {
            Sex = sex;
            IsRideable = isRideable;
            IsFeconded = isFeconded;
            IsFecondationReady = isFecondationReady;
            Id_ = id_;
            ExpirationDate = expirationDate;
            Model = model;
            Name = name;
            Owner = owner;
            Level = level;
            ReproductionCount = reproductionCount;
            ReproductionCountMax = reproductionCountMax;
            Effects = effects;
            Capacities = capacities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Sex);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsRideable);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, IsFeconded);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, IsFecondationReady);
            writer.WriteByte(box0);
            writer.WriteVarLong(Id_);
            writer.WriteVarLong(ExpirationDate);
            writer.WriteVarInt(Model);
            writer.WriteUTF(Name);
            writer.WriteUTF(Owner);
            writer.WriteByte(Level);
            writer.WriteVarInt(ReproductionCount);
            writer.WriteVarInt(ReproductionCountMax);
            writer.WriteShort((short)Effects.Count());
            foreach (var current in Effects)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Capacities.Count());
            foreach (var current in Capacities)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(box0, 1);
            IsRideable = BooleanByteWrapper.GetFlag(box0, 2);
            IsFeconded = BooleanByteWrapper.GetFlag(box0, 3);
            IsFecondationReady = BooleanByteWrapper.GetFlag(box0, 4);
            Id_ = reader.ReadVarLong();
            ExpirationDate = reader.ReadVarLong();
            Model = reader.ReadVarInt();
            Name = reader.ReadUTF();
            Owner = reader.ReadUTF();
            Level = reader.ReadByte();
            ReproductionCount = reader.ReadVarInt();
            ReproductionCountMax = reader.ReadVarInt();
            var countEffects = reader.ReadShort();
            Effects = new List<ObjectEffectInteger>();
            for (short i = 0; i < countEffects; i++)
            {
                ObjectEffectInteger type = new ObjectEffectInteger();
                type.Deserialize(reader);
                Effects.Add(type);
            }
            var countCapacities = reader.ReadShort();
            Capacities = new List<int>();
            for (short i = 0; i < countCapacities; i++)
            {
                Capacities.Add(reader.ReadVarInt());
            }
        }
    }
}