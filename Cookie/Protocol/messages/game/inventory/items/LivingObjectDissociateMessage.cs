using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LivingObjectDissociateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5723;
        public override uint MessageID { get { return ProtocolId; } }

        public int LivingUID = 0;
        public byte LivingPosition = 0;

        public LivingObjectDissociateMessage()
        {
        }

        public LivingObjectDissociateMessage(
            int livingUID,
            byte livingPosition
        )
        {
            LivingUID = livingUID;
            LivingPosition = livingPosition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(LivingUID);
            writer.WriteByte(LivingPosition);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LivingUID = reader.ReadVarInt();
            LivingPosition = reader.ReadByte();
        }
    }
}