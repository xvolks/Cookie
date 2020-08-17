using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountInformationInPaddockRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5975;

        public MountInformationInPaddockRequestMessage(int mapRideId)
        {
            MapRideId = mapRideId;
        }

        public MountInformationInPaddockRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MapRideId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MapRideId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapRideId = reader.ReadVarInt();
        }
    }
}