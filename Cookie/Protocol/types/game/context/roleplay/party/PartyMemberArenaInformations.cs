using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PartyMemberArenaInformations : PartyMemberInformations
    {
        public new const short ProtocolId = 391;
        public override short TypeId { get { return ProtocolId; } }

        public short Rank = 0;

        public PartyMemberArenaInformations(): base()
        {
        }

        public PartyMemberArenaInformations(
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
            List<PartyEntityBaseInformation> entities,
            short rank
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed,
            sex,
            lifePoints,
            maxLifePoints,
            prospecting,
            regenRate,
            initiative,
            alignmentSide,
            worldX,
            worldY,
            mapId,
            subAreaId,
            status,
            entities
        )
        {
            Rank = rank;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Rank);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarShort();
        }
    }
}