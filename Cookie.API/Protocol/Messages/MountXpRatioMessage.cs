using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountXpRatioMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5970;

        public override ushort MessageID => ProtocolId;

        public sbyte Ratio { get; set; }
        public MountXpRatioMessage() { }

        public MountXpRatioMessage( sbyte Ratio ){
            this.Ratio = Ratio;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Ratio);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ratio = reader.ReadSByte();
        }
    }
}
