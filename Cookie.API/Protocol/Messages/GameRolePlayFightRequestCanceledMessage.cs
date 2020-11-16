using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5822;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public double SourceId { get; set; }
        public double TargetId { get; set; }
        public GameRolePlayFightRequestCanceledMessage() { }

        public GameRolePlayFightRequestCanceledMessage( ushort FightId, double SourceId, double TargetId ){
            this.FightId = FightId;
            this.SourceId = SourceId;
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteDouble(SourceId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            SourceId = reader.ReadDouble();
            TargetId = reader.ReadDouble();
        }
    }
}
