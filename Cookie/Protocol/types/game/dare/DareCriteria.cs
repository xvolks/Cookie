using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class DareCriteria : NetworkType
    {
        public const short ProtocolId = 501;
        public override short TypeId { get { return ProtocolId; } }

        public byte Type = 0;
        public List<int> Params_;

        public DareCriteria()
        {
        }

        public DareCriteria(
            byte type,
            List<int> params_
        )
        {
            Type = type;
            Params_ = params_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short)Params_.Count());
            foreach (var current in Params_)
            {
                writer.WriteInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            var countParams_ = reader.ReadShort();
            Params_ = new List<int>();
            for (short i = 0; i < countParams_; i++)
            {
                Params_.Add(reader.ReadInt());
            }
        }
    }
}