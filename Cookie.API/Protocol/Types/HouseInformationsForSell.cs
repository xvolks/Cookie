using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseInformationsForSell : NetworkType
    {
        public const ushort ProtocolId = 221;

        public override ushort TypeID => ProtocolId;

        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public uint ModelId { get; set; }
        public string OwnerName { get; set; }
        public bool OwnerConnected { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public ushort SubAreaId { get; set; }
        public sbyte NbRoom { get; set; }
        public sbyte NbChest { get; set; }
        public List<int> SkillListIds { get; set; }
        public bool IsLocked { get; set; }
        public ulong Price { get; set; }
        public HouseInformationsForSell() { }

        public HouseInformationsForSell( int InstanceId, bool SecondHand, uint ModelId, string OwnerName, bool OwnerConnected, short WorldX, short WorldY, ushort SubAreaId, sbyte NbRoom, sbyte NbChest, List<int> SkillListIds, bool IsLocked, ulong Price ){
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
            this.ModelId = ModelId;
            this.OwnerName = OwnerName;
            this.OwnerConnected = OwnerConnected;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.SubAreaId = SubAreaId;
            this.NbRoom = NbRoom;
            this.NbChest = NbChest;
            this.SkillListIds = SkillListIds;
            this.IsLocked = IsLocked;
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteVarUhInt(ModelId);
            writer.WriteUTF(OwnerName);
            writer.WriteBoolean(OwnerConnected);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(NbRoom);
            writer.WriteSByte(NbChest);
			writer.WriteShort((short)SkillListIds.Count);
			foreach (var x in SkillListIds)
			{
				writer.WriteInt(x);
			}
            writer.WriteBoolean(IsLocked);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            ModelId = reader.ReadVarUhInt();
            OwnerName = reader.ReadUTF();
            OwnerConnected = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarUhShort();
            NbRoom = reader.ReadSByte();
            NbChest = reader.ReadSByte();
            var SkillListIdsCount = reader.ReadShort();
            SkillListIds = new List<int>();
            for (var i = 0; i < SkillListIdsCount; i++)
            {
                SkillListIds.Add(reader.ReadInt());
            }
            IsLocked = reader.ReadBoolean();
            Price = reader.ReadVarUhLong();
        }
    }
}
