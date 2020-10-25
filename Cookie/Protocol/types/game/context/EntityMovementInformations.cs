using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class EntityMovementInformations : NetworkType
    {
        public const short ProtocolId = 63;
        public override short TypeId { get { return ProtocolId; } }

        public int Id_ = 0;
        public List<byte> Steps;

        public EntityMovementInformations()
        {
        }

        public EntityMovementInformations(
            int id_,
            List<byte> steps
        )
        {
            Id_ = id_;
            Steps = steps;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Id_);
            writer.WriteShort((short)Steps.Count());
            foreach (var current in Steps)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadInt();
            var countSteps = reader.ReadShort();
            Steps = new List<byte>();
            for (short i = 0; i < countSteps; i++)
            {
                Steps.Add(reader.ReadByte());
            }
        }
    }
}