using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountXpRatioMessage : NetworkMessage
    {
        public const uint ProtocolId = 5970;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Ratio = 0;

        public MountXpRatioMessage()
        {
        }

        public MountXpRatioMessage(
            byte ratio
        )
        {
            Ratio = ratio;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Ratio);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Ratio = reader.ReadByte();
        }
    }
}