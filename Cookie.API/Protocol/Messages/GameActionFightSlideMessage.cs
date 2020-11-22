using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightSlideMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5525;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public short StartCellId { get; set; }
        public short EndCellId { get; set; }
        public GameActionFightSlideMessage() { }

        public GameActionFightSlideMessage( double TargetId, short StartCellId, short EndCellId ){
            this.TargetId = TargetId;
            this.StartCellId = StartCellId;
            this.EndCellId = EndCellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(StartCellId);
            writer.WriteShort(EndCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            StartCellId = reader.ReadShort();
            EndCellId = reader.ReadShort();
        }
    }
}
