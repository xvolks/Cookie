using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeCrafterJobLevelupMessage : NetworkMessage
    {
        public const uint ProtocolId = 6598;
        public override uint MessageID { get { return ProtocolId; } }

        public byte CrafterJobLevel = 0;

        public ExchangeCrafterJobLevelupMessage()
        {
        }

        public ExchangeCrafterJobLevelupMessage(
            byte crafterJobLevel
        )
        {
            CrafterJobLevel = crafterJobLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CrafterJobLevel = reader.ReadByte();
        }
    }
}