using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class UpdateSelfAgressableStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6456;

        public override ushort MessageID => ProtocolId;

        public sbyte Status { get; set; }
        public int ProbationTime { get; set; }
        public UpdateSelfAgressableStatusMessage() { }

        public UpdateSelfAgressableStatusMessage( sbyte Status, int ProbationTime ){
            this.Status = Status;
            this.ProbationTime = ProbationTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Status);
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadSByte();
            ProbationTime = reader.ReadInt();
        }
    }
}
