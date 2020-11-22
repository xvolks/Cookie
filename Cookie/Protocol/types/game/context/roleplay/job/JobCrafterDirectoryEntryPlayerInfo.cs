using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobCrafterDirectoryEntryPlayerInfo : NetworkType
    {
        public const short ProtocolId = 194;
        public override short TypeId { get { return ProtocolId; } }

        public long PlayerId = 0;
        public string PlayerName;
        public byte AlignmentSide = 0;
        public byte Breed = 0;
        public bool Sex = false;
        public bool IsInWorkshop = false;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public PlayerStatus Status;

        public JobCrafterDirectoryEntryPlayerInfo()
        {
        }

        public JobCrafterDirectoryEntryPlayerInfo(
            long playerId,
            string playerName,
            byte alignmentSide,
            byte breed,
            bool sex,
            bool isInWorkshop,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            PlayerStatus status
        )
        {
            PlayerId = playerId;
            PlayerName = playerName;
            AlignmentSide = alignmentSide;
            Breed = breed;
            Sex = sex;
            IsInWorkshop = isInWorkshop;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteByte(AlignmentSide);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteBoolean(IsInWorkshop);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            AlignmentSide = reader.ReadByte();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            IsInWorkshop = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}