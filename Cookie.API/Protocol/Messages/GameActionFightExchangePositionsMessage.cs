using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5527;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public short CasterCellId { get; set; }
        public short TargetCellId { get; set; }
        public GameActionFightExchangePositionsMessage() { }

        public GameActionFightExchangePositionsMessage( double TargetId, short CasterCellId, short TargetCellId ){
            this.TargetId = TargetId;
            this.CasterCellId = CasterCellId;
            this.TargetCellId = TargetCellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CasterCellId);
            writer.WriteShort(TargetCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CasterCellId = reader.ReadShort();
            TargetCellId = reader.ReadShort();
        }
    }
}
