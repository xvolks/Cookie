using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class HouseInformationsForSell : NetworkType
    {
        public const short ProtocolId = 221;
        public override short TypeId { get { return ProtocolId; } }

        public int InstanceId = 0;
        public bool SecondHand = false;
        public int ModelId = 0;
        public string OwnerName;
        public bool OwnerConnected = false;
        public short WorldX = 0;
        public short WorldY = 0;
        public short SubAreaId = 0;
        public byte NbRoom = 0;
        public byte NbChest = 0;
        public List<int> SkillListIds;
        public bool IsLocked = false;
        public long Price = 0;

        public HouseInformationsForSell()
        {
        }

        public HouseInformationsForSell(
            int instanceId,
            bool secondHand,
            int modelId,
            string ownerName,
            bool ownerConnected,
            short worldX,
            short worldY,
            short subAreaId,
            byte nbRoom,
            byte nbChest,
            List<int> skillListIds,
            bool isLocked,
            long price
        )
        {
            InstanceId = instanceId;
            SecondHand = secondHand;
            ModelId = modelId;
            OwnerName = ownerName;
            OwnerConnected = ownerConnected;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            NbRoom = nbRoom;
            NbChest = nbChest;
            SkillListIds = skillListIds;
            IsLocked = isLocked;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteVarInt(ModelId);
            writer.WriteUTF(OwnerName);
            writer.WriteBoolean(OwnerConnected);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarShort(SubAreaId);
            writer.WriteByte(NbRoom);
            writer.WriteByte(NbChest);
            writer.WriteShort((short)SkillListIds.Count());
            foreach (var current in SkillListIds)
            {
                writer.WriteInt(current);
            }
            writer.WriteBoolean(IsLocked);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            ModelId = reader.ReadVarInt();
            OwnerName = reader.ReadUTF();
            OwnerConnected = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarShort();
            NbRoom = reader.ReadByte();
            NbChest = reader.ReadByte();
            var countSkillListIds = reader.ReadShort();
            SkillListIds = new List<int>();
            for (short i = 0; i < countSkillListIds; i++)
            {
                SkillListIds.Add(reader.ReadInt());
            }
            IsLocked = reader.ReadBoolean();
            Price = reader.ReadVarLong();
        }
    }
}