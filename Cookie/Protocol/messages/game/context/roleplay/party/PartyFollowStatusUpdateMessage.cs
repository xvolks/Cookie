using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5581;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;
        public bool IsFollowed = false;
        public long FollowedId = 0;

        public PartyFollowStatusUpdateMessage(): base()
        {
        }

        public PartyFollowStatusUpdateMessage(
            int partyId,
            bool success,
            bool isFollowed,
            long followedId
        ): base(
            partyId
        )
        {
            Success = success;
            IsFollowed = isFollowed;
            FollowedId = followedId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Success);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, IsFollowed);
            writer.WriteByte(box0);
            writer.WriteVarLong(FollowedId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(box0, 1);
            IsFollowed = BooleanByteWrapper.GetFlag(box0, 2);
            FollowedId = reader.ReadVarLong();
        }
    }
}