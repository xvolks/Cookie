using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareRewardConsumeValidationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6675;

        public override ushort MessageID => ProtocolId;

        public double DareId { get; set; }
        public sbyte Type { get; set; }
        public DareRewardConsumeValidationMessage() { }

        public DareRewardConsumeValidationMessage( double DareId, sbyte Type ){
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
