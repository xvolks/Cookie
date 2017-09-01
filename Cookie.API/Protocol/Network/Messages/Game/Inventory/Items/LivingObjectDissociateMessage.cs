using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class LivingObjectDissociateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5723;

        public LivingObjectDissociateMessage(uint livingUID, byte livingPosition)
        {
            LivingUID = livingUID;
            LivingPosition = livingPosition;
        }

        public LivingObjectDissociateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint LivingUID { get; set; }
        public byte LivingPosition { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LivingUID);
            writer.WriteByte(LivingPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            LivingUID = reader.ReadVarUhInt();
            LivingPosition = reader.ReadByte();
        }
    }
}