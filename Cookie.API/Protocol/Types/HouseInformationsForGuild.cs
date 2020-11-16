using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseInformationsForGuild : HouseInformations
    {
        public new const ushort ProtocolId = 170;

        public override ushort TypeID => ProtocolId;

        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public string OwnerName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public List<int> SkillListIds { get; set; }
        public uint GuildshareParams { get; set; }
        public HouseInformationsForGuild() { }

        public HouseInformationsForGuild( int InstanceId, bool SecondHand, string OwnerName, short WorldX, short WorldY, double MapId, ushort SubAreaId, List<int> SkillListIds, uint GuildshareParams ){
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
            this.OwnerName = OwnerName;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.SkillListIds = SkillListIds;
            this.GuildshareParams = GuildshareParams;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
			writer.WriteShort((short)SkillListIds.Count);
			foreach (var x in SkillListIds)
			{
				writer.WriteInt(x);
			}
            writer.WriteVarUhInt(GuildshareParams);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            OwnerName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            var SkillListIdsCount = reader.ReadShort();
            SkillListIds = new List<int>();
            for (var i = 0; i < SkillListIdsCount; i++)
            {
                SkillListIds.Add(reader.ReadInt());
            }
            GuildshareParams = reader.ReadVarUhInt();
        }
    }
}
