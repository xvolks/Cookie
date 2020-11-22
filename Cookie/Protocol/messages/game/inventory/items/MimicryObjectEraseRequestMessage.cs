using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MimicryObjectEraseRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6457;
        public override uint MessageID { get { return ProtocolId; } }

        public int HostUID = 0;
        public byte HostPos = 0;

        public MimicryObjectEraseRequestMessage()
        {
        }

        public MimicryObjectEraseRequestMessage(
            int hostUID,
            byte hostPos
        )
        {
            HostUID = hostUID;
            HostPos = hostPos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HostUID = reader.ReadVarInt();
            HostPos = reader.ReadByte();
        }
    }
}