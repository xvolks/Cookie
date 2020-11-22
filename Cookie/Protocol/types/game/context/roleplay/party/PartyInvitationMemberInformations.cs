using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PartyInvitationMemberInformations : CharacterBaseInformations
    {
        public new const short ProtocolId = 376;
        public override short TypeId { get { return ProtocolId; } }

        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public List<PartyEntityBaseInformation> Entities;

        public PartyInvitationMemberInformations(): base()
        {
        }

        public PartyInvitationMemberInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            bool sex,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
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
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            Entities = entities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteShort((short)Entities.Count());
            foreach (var current in Entities)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            var countEntities = reader.ReadShort();
            Entities = new List<PartyEntityBaseInformation>();
            for (short i = 0; i < countEntities; i++)
            {
                PartyEntityBaseInformation type = new PartyEntityBaseInformation();
                type.Deserialize(reader);
                Entities.Add(type);
            }
        }
    }
}