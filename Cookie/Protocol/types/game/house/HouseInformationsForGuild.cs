using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class HouseInformationsForGuild : HouseInformations
    {
        public new const short ProtocolId = 170;
        public override short TypeId { get { return ProtocolId; } }

        public int InstanceId = 0;
        public bool SecondHand = false;
        public string OwnerName;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public List<int> SkillListIds;
        public int GuildshareParams = 0;

        public HouseInformationsForGuild(): base()
        {
        }

        public HouseInformationsForGuild(
            int houseId,
            short modelId,
            int instanceId,
            bool secondHand,
            string ownerName,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            List<int> skillListIds,
            int guildshareParams
        ): base(
            houseId,
            modelId
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
            writer.WriteUTF(OwnerName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteShort((short)SkillListIds.Count());
            foreach (var current in SkillListIds)
            {
                writer.WriteInt(current);
            }
            writer.WriteVarInt(GuildshareParams);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
            OwnerName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            var countSkillListIds = reader.ReadShort();
            SkillListIds = new List<int>();
            for (short i = 0; i < countSkillListIds; i++)
            {
                SkillListIds.Add(reader.ReadInt());
            }
            GuildshareParams = reader.ReadVarInt();
        }
    }
}