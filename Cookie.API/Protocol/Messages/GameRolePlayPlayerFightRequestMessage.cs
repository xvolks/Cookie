using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5731;

        public override ushort MessageID => ProtocolId;

        public ulong TargetId { get; set; }
        public short TargetCellId { get; set; }
        public bool Friendly { get; set; }
        public GameRolePlayPlayerFightRequestMessage() { }

        public GameRolePlayPlayerFightRequestMessage( ulong TargetId, short TargetCellId, bool Friendly ){
            this.TargetId = TargetId;
            this.TargetCellId = TargetCellId;
            this.Friendly = Friendly;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(TargetId);
            writer.WriteShort(TargetCellId);
            writer.WriteBoolean(Friendly);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarUhLong();
            TargetCellId = reader.ReadShort();
            Friendly = reader.ReadBoolean();
        }
    }
}
