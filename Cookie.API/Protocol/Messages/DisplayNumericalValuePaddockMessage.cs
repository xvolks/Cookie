using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DisplayNumericalValuePaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6563;

        public override ushort MessageID => ProtocolId;

        public int RideId { get; set; }
        public int Value { get; set; }
        public sbyte Type { get; set; }
        public DisplayNumericalValuePaddockMessage() { }

        public DisplayNumericalValuePaddockMessage( int RideId, int Value, sbyte Type ){
            this.RideId = RideId;
            this.Value = Value;
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RideId);
            writer.WriteInt(Value);
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            RideId = reader.ReadInt();
            Value = reader.ReadInt();
            Type = reader.ReadSByte();
        }
    }
}
