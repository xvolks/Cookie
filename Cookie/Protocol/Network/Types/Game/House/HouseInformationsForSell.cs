using System.Collections.Generic;
using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.House
{
    public class HouseInformationsForSell : NetworkType
    {
        public const short ProtocolId = 221;

        private int m_instanceId;

        private bool m_isLocked;

        private uint m_modelId;

        private byte m_nbChest;

        private byte m_nbRoom;

        private bool m_ownerConnected;

        private string m_ownerName;

        private ulong m_price;

        private bool m_secondHand;

        private List<int> m_skillListIds;

        private ushort m_subAreaId;

        private short m_worldX;

        private short m_worldY;

        public HouseInformationsForSell(List<int> skillListIds, int instanceId, bool secondHand, uint modelId,
            string ownerName, bool ownerConnected, short worldX, short worldY, ushort subAreaId, byte nbRoom,
            byte nbChest, bool isLocked, ulong price)
        {
            m_skillListIds = skillListIds;
            m_instanceId = instanceId;
            m_secondHand = secondHand;
            m_modelId = modelId;
            m_ownerName = ownerName;
            m_ownerConnected = ownerConnected;
            m_worldX = worldX;
            m_worldY = worldY;
            m_subAreaId = subAreaId;
            m_nbRoom = nbRoom;
            m_nbChest = nbChest;
            m_isLocked = isLocked;
            m_price = price;
        }

        public HouseInformationsForSell()
        {
        }

        public override short TypeID => ProtocolId;

        public virtual int InstanceId
        {
            get => m_instanceId;
            set => m_instanceId = value;
        }

        public virtual bool SecondHand
        {
            get => m_secondHand;
            set => m_secondHand = value;
        }

        public virtual uint ModelId
        {
            get => m_modelId;
            set => m_modelId = value;
        }

        public virtual string OwnerName
        {
            get => m_ownerName;
            set => m_ownerName = value;
        }

        public virtual bool OwnerConnected
        {
            get => m_ownerConnected;
            set => m_ownerConnected = value;
        }

        public virtual short WorldX
        {
            get => m_worldX;
            set => m_worldX = value;
        }

        public virtual short WorldY
        {
            get => m_worldY;
            set => m_worldY = value;
        }

        public virtual ushort SubAreaId
        {
            get => m_subAreaId;
            set => m_subAreaId = value;
        }

        public virtual byte NbRoom
        {
            get => m_nbRoom;
            set => m_nbRoom = value;
        }

        public virtual byte NbChest
        {
            get => m_nbChest;
            set => m_nbChest = value;
        }

        public virtual List<int> SkillListIds
        {
            get => m_skillListIds;
            set => m_skillListIds = value;
        }

        public virtual bool IsLocked
        {
            get => m_isLocked;
            set => m_isLocked = value;
        }

        public virtual ulong Price
        {
            get => m_price;
            set => m_price = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(m_instanceId);
            writer.WriteBoolean(m_secondHand);
            writer.WriteVarUhInt(m_modelId);
            writer.WriteUTF(m_ownerName);
            writer.WriteBoolean(m_ownerConnected);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteByte(m_nbRoom);
            writer.WriteByte(m_nbChest);
            writer.WriteShort((short) m_skillListIds.Count);
            int skillListIdsIndex;
            for (skillListIdsIndex = 0;
                skillListIdsIndex < m_skillListIds.Count;
                skillListIdsIndex = skillListIdsIndex + 1)
                writer.WriteInt(m_skillListIds[skillListIdsIndex]);
            writer.WriteBoolean(m_isLocked);
            writer.WriteVarUhLong(m_price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            m_instanceId = reader.ReadInt();
            m_secondHand = reader.ReadBoolean();
            m_modelId = reader.ReadVarUhInt();
            m_ownerName = reader.ReadUTF();
            m_ownerConnected = reader.ReadBoolean();
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_subAreaId = reader.ReadVarUhShort();
            m_nbRoom = reader.ReadByte();
            m_nbChest = reader.ReadByte();
            int skillListIdsCount = reader.ReadUShort();
            int skillListIdsIndex;
            m_skillListIds = new List<int>();
            for (skillListIdsIndex = 0;
                skillListIdsIndex < skillListIdsCount;
                skillListIdsIndex = skillListIdsIndex + 1)
                m_skillListIds.Add(reader.ReadInt());
            m_isLocked = reader.ReadBoolean();
            m_price = reader.ReadVarUhLong();
        }
    }
}