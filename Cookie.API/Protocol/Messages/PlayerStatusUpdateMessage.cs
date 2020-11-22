using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PlayerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6386;

        public override ushort MessageID => ProtocolId;

        public int AccountId { get; set; }
        public ulong PlayerId { get; set; }
        public PlayerStatus Status { get; set; }
        public PlayerStatusUpdateMessage() { }

        public PlayerStatusUpdateMessage( int AccountId, ulong PlayerId, PlayerStatus Status ){
            this.AccountId = AccountId;
            this.PlayerId = PlayerId;
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarUhLong(PlayerId);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
