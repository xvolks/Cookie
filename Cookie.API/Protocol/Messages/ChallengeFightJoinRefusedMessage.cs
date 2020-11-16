using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChallengeFightJoinRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5908;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public sbyte Reason { get; set; }
        public ChallengeFightJoinRefusedMessage() { }

        public ChallengeFightJoinRefusedMessage( ulong PlayerId, sbyte Reason ){
            this.PlayerId = PlayerId;
            this.Reason = Reason;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            Reason = reader.ReadSByte();
        }
    }
}
