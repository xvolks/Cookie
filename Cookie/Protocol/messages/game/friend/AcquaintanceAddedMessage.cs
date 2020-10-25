using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AcquaintanceAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6818;
        public override uint MessageID { get { return ProtocolId; } }

        public AcquaintanceInformation AcquaintanceAdded;

        public AcquaintanceAddedMessage()
        {
        }

        public AcquaintanceAddedMessage(
            AcquaintanceInformation acquaintanceAdded
        )
        {
            AcquaintanceAdded = acquaintanceAdded;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(AcquaintanceAdded.TypeId);
            AcquaintanceAdded.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var acquaintanceAddedTypeId = reader.ReadShort();
            AcquaintanceAdded = new AcquaintanceInformation();
            AcquaintanceAdded.Deserialize(reader);
        }
    }
}