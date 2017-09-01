using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    public class UpdateSelfAgressableStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6456;

        public UpdateSelfAgressableStatusMessage(byte status, int probationTime)
        {
            Status = status;
            ProbationTime = probationTime;
        }

        public UpdateSelfAgressableStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Status { get; set; }
        public int ProbationTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Status);
            writer.WriteInt(ProbationTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadByte();
            ProbationTime = reader.ReadInt();
        }
    }
}