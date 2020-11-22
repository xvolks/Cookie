using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountSetXpRatioRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5989;
        public override uint MessageID { get { return ProtocolId; } }

        public byte XpRatio = 0;

        public MountSetXpRatioRequestMessage()
        {
        }

        public MountSetXpRatioRequestMessage(
            byte xpRatio
        )
        {
            XpRatio = xpRatio;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(XpRatio);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            XpRatio = reader.ReadByte();
        }
    }
}