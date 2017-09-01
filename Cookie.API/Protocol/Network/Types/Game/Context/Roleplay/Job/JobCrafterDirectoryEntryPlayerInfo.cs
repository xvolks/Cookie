using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryPlayerInfo : NetworkType
    {
        public const ushort ProtocolId = 194;

        public JobCrafterDirectoryEntryPlayerInfo(ulong playerId, string playerName, sbyte alignmentSide, sbyte breed,
            bool sex, bool isInWorkshop, short worldX, short worldY, int mapId, ushort subAreaId, PlayerStatus status)
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

        public JobCrafterDirectoryEntryPlayerInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public bool IsInWorkshop { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public PlayerStatus Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(AlignmentSide);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteBoolean(IsInWorkshop);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            AlignmentSide = reader.ReadSByte();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            IsInWorkshop = reader.ReadBoolean();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}