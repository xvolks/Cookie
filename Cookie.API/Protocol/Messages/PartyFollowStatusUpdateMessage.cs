using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5581;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public bool IsFollowed { get; set; }
        public ulong FollowedId { get; set; }
        public PartyFollowStatusUpdateMessage() { }

        public PartyFollowStatusUpdateMessage( bool Success, bool IsFollowed, ulong FollowedId ){
            this.Success = Success;
            this.IsFollowed = IsFollowed;
            this.FollowedId = FollowedId;
        }

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
			Success = BooleanByteWrapper.GetFlag(flag, 0);;
			IsFollowed = BooleanByteWrapper.GetFlag(flag, 1);;
            FollowedId = reader.ReadVarUhLong();
        }
    }
}
