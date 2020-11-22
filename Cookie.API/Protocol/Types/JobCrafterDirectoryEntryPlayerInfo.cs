using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobCrafterDirectoryEntryPlayerInfo : NetworkType
    {
        public const ushort ProtocolId = 194;

        public override ushort TypeID => ProtocolId;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte AlignmentSide { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public bool IsInWorkshop { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public PlayerStatus Status { get; set; }
        public JobCrafterDirectoryEntryPlayerInfo() { }

        public JobCrafterDirectoryEntryPlayerInfo( ulong PlayerId, string PlayerName, sbyte AlignmentSide, sbyte Breed, bool Sex, bool IsInWorkshop, short WorldX, short WorldY, double MapId, ushort SubAreaId, PlayerStatus Status ){
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.AlignmentSide = AlignmentSide;
            this.Breed = Breed;
            this.Sex = Sex;
            this.IsInWorkshop = IsInWorkshop;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Status = Status;
        }

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
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
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
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
