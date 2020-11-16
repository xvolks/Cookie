using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PartyMemberInformations : CharacterBaseInformations
    {
        public new const short ProtocolId = 90;
        public override short TypeId { get { return ProtocolId; } }

        public int LifePoints = 0;
        public int MaxLifePoints = 0;
        public short Prospecting = 0;
        public byte RegenRate = 0;
        public short Initiative = 0;
        public byte AlignmentSide = 0;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public PlayerStatus Status;
        public List<PartyEntityBaseInformation> Entities;

        public PartyMemberInformations(): base()
        {
        }

        public PartyMemberInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            bool sex,
            int lifePoints,
            int maxLifePoints,
            short prospecting,
            byte regenRate,
            short initiative,
            byte alignmentSide,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            PlayerStatus status,
            List<PartyEntityBaseInformation> entities
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed,
            sex
        )
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
            Initiative = initiative;
            AlignmentSide = alignmentSide;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Status = status;
            Entities = entities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(LifePoints);
            writer.WriteVarInt(MaxLifePoints);
            writer.WriteVarShort(Prospecting);
            writer.WriteByte(RegenRate);
            writer.WriteVarShort(Initiative);
            writer.WriteByte(AlignmentSide);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
            writer.WriteShort((short)Entities.Count());
            foreach (var current in Entities)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LifePoints = reader.ReadVarInt();
            MaxLifePoints = reader.ReadVarInt();
            Prospecting = reader.ReadVarShort();
            RegenRate = reader.ReadByte();
            Initiative = reader.ReadVarShort();
            AlignmentSide = reader.ReadByte();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
            var countEntities = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (short i = 0; i < countEntities; i++)
            {
                var entitiestypeId = reader.ReadShort();
                PartyEntityBaseInformation type = new PartyEntityBaseInformation();
                type.Deserialize(reader);
                Entities.Add(type);
            }
        }
    }
}