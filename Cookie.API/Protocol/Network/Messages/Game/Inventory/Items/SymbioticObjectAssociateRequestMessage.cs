using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class SymbioticObjectAssociateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6522;

        public SymbioticObjectAssociateRequestMessage(uint symbioteUID, byte symbiotePos, uint hostUID, byte hostPos)
        {
            SymbioteUID = symbioteUID;
            SymbiotePos = symbiotePos;
            HostUID = hostUID;
            HostPos = hostPos;
        }

        public SymbioticObjectAssociateRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint SymbioteUID { get; set; }
        public byte SymbiotePos { get; set; }
        public uint HostUID { get; set; }
        public byte HostPos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SymbioteUID);
            writer.WriteByte(SymbiotePos);
            writer.WriteVarUhInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(IDataReader reader)
        {
            SymbioteUID = reader.ReadVarUhInt();
            SymbiotePos = reader.ReadByte();
            HostUID = reader.ReadVarUhInt();
            HostPos = reader.ReadByte();
        }
    }
}