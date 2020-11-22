using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class UpdateSelfAgressableStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6456;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Status = 0;
        public int ProbationTime = 0;

        public UpdateSelfAgressableStatusMessage()
        {
        }

        public UpdateSelfAgressableStatusMessage(
            byte status,
            int probationTime
        )
        {
            Status = status;
            ProbationTime = probationTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Status);
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Status = reader.ReadByte();
            ProbationTime = reader.ReadInt();
        }
    }
}