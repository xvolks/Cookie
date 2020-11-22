using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DareReward : NetworkType
    {
        public const ushort ProtocolId = 505;

        public override ushort TypeID => ProtocolId;

        public sbyte Type { get; set; }
        public ushort MonsterId { get; set; }
        public ulong Kamas { get; set; }
        public double DareId { get; set; }
        public DareReward() { }

        public DareReward( sbyte Type, ushort MonsterId, ulong Kamas, double DareId ){
            this.Type = Type;
            this.MonsterId = MonsterId;
            this.Kamas = Kamas;
            this.DareId = DareId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteVarUhShort(MonsterId);
            writer.WriteVarUhLong(Kamas);
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            MonsterId = reader.ReadVarUhShort();
            Kamas = reader.ReadVarUhLong();
            DareId = reader.ReadDouble();
        }
    }
}
