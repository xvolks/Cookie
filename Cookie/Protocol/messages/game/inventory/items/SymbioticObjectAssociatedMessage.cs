using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SymbioticObjectAssociatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6527;
        public override uint MessageID { get { return ProtocolId; } }

        public int HostUID = 0;

        public SymbioticObjectAssociatedMessage()
        {
        }

        public SymbioticObjectAssociatedMessage(
            int hostUID
        )
        {
            HostUID = hostUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HostUID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HostUID = reader.ReadVarInt();
        }
    }
}