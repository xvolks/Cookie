using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountFeedRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6189;
        public override uint MessageID { get { return ProtocolId; } }

        public int MountUid = 0;
        public byte MountLocation = 0;
        public int MountFoodUid = 0;
        public int Quantity = 0;

        public MountFeedRequestMessage()
        {
        }

        public MountFeedRequestMessage(
            int mountUid,
            byte mountLocation,
            int mountFoodUid,
            int quantity
        )
        {
            MountUid = mountUid;
            MountLocation = mountLocation;
            MountFoodUid = mountFoodUid;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MountUid);
            writer.WriteByte(MountLocation);
            writer.WriteVarInt(MountFoodUid);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MountUid = reader.ReadVarInt();
            MountLocation = reader.ReadByte();
            MountFoodUid = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}