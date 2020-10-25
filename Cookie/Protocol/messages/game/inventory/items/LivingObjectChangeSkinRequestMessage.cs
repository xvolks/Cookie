using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LivingObjectChangeSkinRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5725;
        public override uint MessageID { get { return ProtocolId; } }

        public int LivingUID = 0;
        public byte LivingPosition = 0;
        public int SkinId = 0;

        public LivingObjectChangeSkinRequestMessage()
        {
        }

        public LivingObjectChangeSkinRequestMessage(
            int livingUID,
            byte livingPosition,
            int skinId
        )
        {
            LivingUID = livingUID;
            LivingPosition = livingPosition;
            SkinId = skinId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(LivingUID);
            writer.WriteByte(LivingPosition);
            writer.WriteVarInt(SkinId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LivingUID = reader.ReadVarInt();
            LivingPosition = reader.ReadByte();
            SkinId = reader.ReadVarInt();
        }
    }
}