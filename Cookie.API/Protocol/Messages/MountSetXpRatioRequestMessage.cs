using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountSetXpRatioRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5989;

        public override ushort MessageID => ProtocolId;

        public sbyte XpRatio { get; set; }
        public MountSetXpRatioRequestMessage() { }

        public MountSetXpRatioRequestMessage( sbyte XpRatio ){
            this.XpRatio = XpRatio;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(XpRatio);
        }

        public override void Deserialize(IDataReader reader)
        {
            XpRatio = reader.ReadSByte();
        }
    }
}
