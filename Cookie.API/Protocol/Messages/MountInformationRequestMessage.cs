using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountInformationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5972;

        public override ushort MessageID => ProtocolId;

        public double Id { get; set; }
        public double Time { get; set; }
        public MountInformationRequestMessage() { }

        public MountInformationRequestMessage( double Id, double Time ){
            this.Id = Id;
            this.Time = Time;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
            writer.WriteDouble(Time);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
            Time = reader.ReadDouble();
        }
    }
}
