using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class FriendSpouseOnlineInformations : FriendSpouseInformations
    {
        public new const ushort ProtocolId = 93;

        public FriendSpouseOnlineInformations(bool inFight, bool followSpouse, int mapId, ushort subAreaId)
        {
            InFight = inFight;
            FollowSpouse = followSpouse;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public FriendSpouseOnlineInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool InFight { get; set; }
        public bool FollowSpouse { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, InFight);
            flag = BooleanByteWrapper.SetFlag(1, flag, FollowSpouse);
            writer.WriteByte(flag);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            InFight = BooleanByteWrapper.GetFlag(flag, 0);
            FollowSpouse = BooleanByteWrapper.GetFlag(flag, 1);
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}