using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareRewardConsumeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6676;

        public override ushort MessageID => ProtocolId;

        public double DareId { get; set; }
        public sbyte Type { get; set; }
        public DareRewardConsumeRequestMessage() { }

        public DareRewardConsumeRequestMessage( double DareId, sbyte Type ){
            this.DareId = DareId;
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Type = reader.ReadSByte();
        }
    }
}
