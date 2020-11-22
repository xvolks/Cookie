using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayPlayerFightFriendlyAnsweredMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5733;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public ulong SourceId { get; set; }
        public ulong TargetId { get; set; }
        public bool Accept { get; set; }
        public GameRolePlayPlayerFightFriendlyAnsweredMessage() { }

        public GameRolePlayPlayerFightFriendlyAnsweredMessage( ushort FightId, ulong SourceId, ulong TargetId, bool Accept ){
            this.FightId = FightId;
            this.SourceId = SourceId;
            this.TargetId = TargetId;
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteVarUhLong(SourceId);
            writer.WriteVarUhLong(TargetId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            SourceId = reader.ReadVarUhLong();
            TargetId = reader.ReadVarUhLong();
            Accept = reader.ReadBoolean();
        }
    }
}
