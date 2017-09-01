using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class MimicryObjectEraseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6457;

        public MimicryObjectEraseRequestMessage(uint hostUID, byte hostPos)
        {
            HostUID = hostUID;
            HostPos = hostPos;
        }

        public MimicryObjectEraseRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HostUID { get; set; }
        public byte HostPos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostUID = reader.ReadVarUhInt();
            HostPos = reader.ReadByte();
        }
    }
}