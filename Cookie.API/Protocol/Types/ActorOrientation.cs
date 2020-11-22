using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ActorOrientation : NetworkType
    {
        public const ushort ProtocolId = 353;

        public override ushort TypeID => ProtocolId;

        public double Id { get; set; }
        public sbyte Direction { get; set; }
        public ActorOrientation() { }

        public ActorOrientation( double Id, sbyte Direction ){
            this.Id = Id;
            this.Direction = Direction;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
            writer.WriteSByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
            Direction = reader.ReadSByte();
        }
    }
}
