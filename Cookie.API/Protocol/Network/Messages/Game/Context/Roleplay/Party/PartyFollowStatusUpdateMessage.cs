using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5581;

        public PartyFollowStatusUpdateMessage(bool success, bool isFollowed, ulong followedId)
        {
            Success = success;
            IsFollowed = isFollowed;
            FollowedId = followedId;
        }

        public PartyFollowStatusUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }
        public bool IsFollowed { get; set; }
        public ulong FollowedId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Success);
            flag = BooleanByteWrapper.SetFlag(1, flag, IsFollowed);
            writer.WriteByte(flag);
            writer.WriteVarUhLong(FollowedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            IsFollowed = BooleanByteWrapper.GetFlag(flag, 1);
            FollowedId = reader.ReadVarUhLong();
        }
    }
}