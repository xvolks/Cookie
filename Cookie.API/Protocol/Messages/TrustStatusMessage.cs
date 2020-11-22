using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TrustStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6267;

        public override ushort MessageID => ProtocolId;

        public bool Trusted { get; set; }
        public bool Certified { get; set; }
        public TrustStatusMessage() { }

        public TrustStatusMessage( bool Trusted, bool Certified ){
            this.Trusted = Trusted;
            this.Certified = Certified;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Trusted);
			flag = BooleanByteWrapper.SetFlag(1, flag, Certified);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Trusted = BooleanByteWrapper.GetFlag(flag, 0);;
			Certified = BooleanByteWrapper.GetFlag(flag, 1);;
        }
    }
}
