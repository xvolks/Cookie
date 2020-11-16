using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightTeleportOnSameMapMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5528;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public short CellId { get; set; }
        public GameActionFightTeleportOnSameMapMessage() { }

        public GameActionFightTeleportOnSameMapMessage( double TargetId, short CellId ){
            this.TargetId = TargetId;
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            CellId = reader.ReadShort();
        }
    }
}
