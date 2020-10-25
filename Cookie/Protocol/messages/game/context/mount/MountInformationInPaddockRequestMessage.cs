using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountInformationInPaddockRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5975;
        public override uint MessageID { get { return ProtocolId; } }

        public int MapRideId = 0;

        public MountInformationInPaddockRequestMessage()
        {
        }

        public MountInformationInPaddockRequestMessage(
            int mapRideId
        )
        {
            MapRideId = mapRideId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MapRideId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapRideId = reader.ReadVarInt();
        }
    }
}