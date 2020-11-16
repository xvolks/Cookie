using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightJoinLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5843;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public bool Join { get; set; }
        public PrismFightJoinLeaveRequestMessage() { }

        public PrismFightJoinLeaveRequestMessage( ushort SubAreaId, bool Join ){
            this.SubAreaId = SubAreaId;
            this.Join = Join;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            Join = reader.ReadBoolean();
        }
    }
}
