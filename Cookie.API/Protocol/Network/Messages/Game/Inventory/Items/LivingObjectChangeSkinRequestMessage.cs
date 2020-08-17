using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class LivingObjectChangeSkinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5725;

        public LivingObjectChangeSkinRequestMessage(uint livingUID, byte livingPosition, uint skinId)
        {
            LivingUID = livingUID;
            LivingPosition = livingPosition;
            SkinId = skinId;
        }

        public LivingObjectChangeSkinRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint LivingUID { get; set; }
        public byte LivingPosition { get; set; }
        public uint SkinId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LivingUID);
            writer.WriteByte(LivingPosition);
            writer.WriteVarUhInt(SkinId);
        }

        public override void Deserialize(IDataReader reader)
        {
            LivingUID = reader.ReadVarUhInt();
            LivingPosition = reader.ReadByte();
            SkinId = reader.ReadVarUhInt();
        }
    }
}