using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismInfoJoinLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5844;

        public override ushort MessageID => ProtocolId;

        public bool Join { get; set; }
        public PrismInfoJoinLeaveRequestMessage() { }

        public PrismInfoJoinLeaveRequestMessage( bool Join ){
            this.Join = Join;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            Join = reader.ReadBoolean();
        }
    }
}
