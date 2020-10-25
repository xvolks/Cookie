using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        public new const short ProtocolId = 93;
        public override short TypeId { get { return ProtocolId; } }

        public bool InFight = false;
        public bool FollowSpouse = false;
        public double MapId = 0;
        public short SubAreaId = 0;

        public FriendSpouseOnlineInformations(): base()
        {
        }

        public FriendSpouseOnlineInformations(
            int spouseAccountId,
            long spouseId,
            string spouseName,
            short spouseLevel,
            byte breed,
            byte sex,
            EntityLook spouseEntityLook,
            GuildInformations guildInfo,
            byte alignmentSide,
            bool inFight,
            bool followSpouse,
            double mapId,
            short subAreaId
        ): base(
            spouseAccountId,
            spouseId,
            spouseName,
            spouseLevel,
            breed,
            sex,
            spouseEntityLook,
            guildInfo,
            alignmentSide
        )
        {
            InFight = inFight;
            FollowSpouse = followSpouse;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, InFight);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, FollowSpouse);
            writer.WriteByte(box0);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            InFight = BooleanByteWrapper.GetFlag(box0, 1);
            FollowSpouse = BooleanByteWrapper.GetFlag(box0, 2);
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
        }
    }
}