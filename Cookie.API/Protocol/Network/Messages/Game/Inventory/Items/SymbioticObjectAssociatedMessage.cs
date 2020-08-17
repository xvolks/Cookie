using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class SymbioticObjectAssociatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6527;

        public SymbioticObjectAssociatedMessage(uint hostUID)
        {
            HostUID = hostUID;
        }

        public SymbioticObjectAssociatedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HostUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HostUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostUID = reader.ReadVarUhInt();
        }
    }
}