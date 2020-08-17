using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountXpRatioMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5970;

        public MountXpRatioMessage(byte ratio)
        {
            Ratio = ratio;
        }

        public MountXpRatioMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Ratio { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Ratio);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ratio = reader.ReadByte();
        }
    }
}