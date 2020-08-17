using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareRewardConsumeValidationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6675;

        public DareRewardConsumeValidationMessage(double dareId, byte type)
        {
            DareId = dareId;
            Type = type;
        }

        public DareRewardConsumeValidationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double DareId { get; set; }
        public byte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Type = reader.ReadByte();
        }
    }
}