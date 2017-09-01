using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.House
{
    public class HouseInformationsForGuild : HouseInformations
    {
        public new const ushort ProtocolId = 170;

        public HouseInformationsForGuild(int instanceId, bool secondHand, string ownerName, short worldX, short worldY,
            int mapId, ushort subAreaId, List<int> skillListIds, uint guildshareParams)
        {
            InstanceId = instanceId;
            SecondHand = secondHand;
            OwnerName = ownerName;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            SkillListIds = skillListIds;
            GuildshareParams = guildshareParams;
        }

        public HouseInformationsForGuild()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public string OwnerName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public List<int> SkillListIds { get; set; }
        public uint GuildshareParams { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteShort((short) SkillListIds.Count);
            for (var skillListIdsIndex = 0; skillListIdsIndex < SkillListIds.Count; skillListIdsIndex++)
                writer.WriteInt(SkillListIds[skillListIdsIndex]);
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
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
            var skillListIdsCount = reader.ReadUShort();
            SkillListIds = new List<int>();
            for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
                SkillListIds.Add(reader.ReadInt());
            GuildshareParams = reader.ReadVarUhInt();
        }
    }
}