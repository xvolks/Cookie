using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountInformationInPaddockRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5975;

        public override ushort MessageID => ProtocolId;

        public int MapRideId { get; set; }
        public MountInformationInPaddockRequestMessage() { }

        public MountInformationInPaddockRequestMessage( int MapRideId ){
            this.MapRideId = MapRideId;
        }

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
