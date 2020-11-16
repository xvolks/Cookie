using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismSetSabotagedRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6466;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public sbyte Reason { get; set; }
        public PrismSetSabotagedRefusedMessage() { }

        public PrismSetSabotagedRefusedMessage( ushort SubAreaId, sbyte Reason ){
            this.SubAreaId = SubAreaId;
            this.Reason = Reason;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            Reason = reader.ReadSByte();
        }
    }
}
