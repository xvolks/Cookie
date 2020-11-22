using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectMount : ObjectEffect
    {
        public new const ushort ProtocolId = 179;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public bool IsRideable { get; set; }
        public bool IsFeconded { get; set; }
        public bool IsFecondationReady { get; set; }
        public ulong Id { get; set; }
        public ulong ExpirationDate { get; set; }
        public uint Model { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public sbyte Level { get; set; }
        public int ReproductionCount { get; set; }
        public uint ReproductionCountMax { get; set; }
        public List<ObjectEffectInteger> Effects { get; set; }
        public List<int> Capacities { get; set; }
        public ObjectEffectMount() { }

        public ObjectEffectMount( bool Sex, bool IsRideable, bool IsFeconded, bool IsFecondationReady, ulong Id, ulong ExpirationDate, uint Model, string Name, string Owner, sbyte Level, int ReproductionCount, uint ReproductionCountMax, List<ObjectEffectInteger> Effects, List<int> Capacities ){
            this.Sex = Sex;
            this.IsRideable = IsRideable;
            this.IsFeconded = IsFeconded;
            this.IsFecondationReady = IsFecondationReady;
            this.Id = Id;
            this.ExpirationDate = ExpirationDate;
            this.Model = Model;
            this.Name = Name;
            this.Owner = Owner;
            this.Level = Level;
            this.ReproductionCount = ReproductionCount;
            this.ReproductionCountMax = ReproductionCountMax;
            this.Effects = Effects;
            this.Capacities = Capacities;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsRideable);
			flag = BooleanByteWrapper.SetFlag(2, flag, IsFeconded);
			flag = BooleanByteWrapper.SetFlag(3, flag, IsFecondationReady);
			writer.WriteByte(flag);
            writer.WriteVarUhLong(Id);
            writer.WriteVarUhLong(ExpirationDate);
            writer.WriteVarUhInt(Model);
            writer.WriteUTF(Name);
            writer.WriteUTF(Owner);
            writer.WriteSByte(Level);
            writer.WriteVarInt(ReproductionCount);
            writer.WriteVarUhInt(ReproductionCountMax);
			writer.WriteShort((short)Effects.Count);
			foreach (var x in Effects)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Capacities.Count);
			foreach (var x in Capacities)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
			var flag = reader.ReadByte();
			Sex = BooleanByteWrapper.GetFlag(flag, 0);
			IsRideable = BooleanByteWrapper.GetFlag(flag, 1);
			IsFeconded = BooleanByteWrapper.GetFlag(flag, 2);
			IsFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
            Id = reader.ReadVarUhLong();
            ExpirationDate = reader.ReadVarUhLong();
            Model = reader.ReadVarUhInt();
            Name = reader.ReadUTF();
            Owner = reader.ReadUTF();
            Level = reader.ReadSByte();
            ReproductionCount = reader.ReadVarInt();
            ReproductionCountMax = reader.ReadVarUhInt();
            var EffectsCount = reader.ReadShort();
            Effects = new List<ObjectEffectInteger>();
            for (var i = 0; i < EffectsCount; i++)
            {
                var objectToAdd = new ObjectEffectInteger();
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            var CapacitiesCount = reader.ReadShort();
            Capacities = new List<int>();
            for (var i = 0; i < CapacitiesCount; i++)
            {
                Capacities.Add(reader.ReadVarInt());
            }
        }
    }
}
