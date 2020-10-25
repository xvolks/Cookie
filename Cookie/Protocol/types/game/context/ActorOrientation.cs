using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ActorOrientation : NetworkType
    {
        public const short ProtocolId = 353;
        public override short TypeId { get { return ProtocolId; } }

        public double Id_ = 0;
        public byte Direction = 1;

        public ActorOrientation()
        {
        }

        public ActorOrientation(
            double id_,
            byte direction
        )
        {
            Id_ = id_;
            Direction = direction;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
            writer.WriteByte(Direction);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
            Direction = reader.ReadByte();
        }
    }
}