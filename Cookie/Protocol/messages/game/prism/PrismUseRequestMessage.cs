using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismUseRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6041;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ModuleToUse = 0;

        public PrismUseRequestMessage()
        {
        }

        public PrismUseRequestMessage(
            byte moduleToUse
        )
        {
            ModuleToUse = moduleToUse;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ModuleToUse);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ModuleToUse = reader.ReadByte();
        }
    }
}