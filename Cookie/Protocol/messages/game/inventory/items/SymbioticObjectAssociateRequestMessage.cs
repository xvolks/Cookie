using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SymbioticObjectAssociateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6522;
        public override uint MessageID { get { return ProtocolId; } }

        public int SymbioteUID = 0;
        public byte SymbiotePos = 0;
        public int HostUID = 0;
        public byte HostPos = 0;

        public SymbioticObjectAssociateRequestMessage()
        {
        }

        public SymbioticObjectAssociateRequestMessage(
            int symbioteUID,
            byte symbiotePos,
            int hostUID,
            byte hostPos
        )
        {
            SymbioteUID = symbioteUID;
            SymbiotePos = symbiotePos;
            HostUID = hostUID;
            HostPos = hostPos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(SymbioteUID);
            writer.WriteByte(SymbiotePos);
            writer.WriteVarInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SymbioteUID = reader.ReadVarInt();
            SymbiotePos = reader.ReadByte();
            HostUID = reader.ReadVarInt();
            HostPos = reader.ReadByte();
        }
    }
}