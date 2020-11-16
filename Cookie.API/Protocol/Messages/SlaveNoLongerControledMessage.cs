using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SlaveNoLongerControledMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6807;

        public override ushort MessageID => ProtocolId;

        public double MasterId { get; set; }
        public double SlaveId { get; set; }
        public SlaveNoLongerControledMessage() { }

        public SlaveNoLongerControledMessage( double MasterId, double SlaveId ){
            this.MasterId = MasterId;
            this.SlaveId = SlaveId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MasterId);
            writer.WriteDouble(SlaveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MasterId = reader.ReadDouble();
            SlaveId = reader.ReadDouble();
        }
    }
}
