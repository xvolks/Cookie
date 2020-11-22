using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5973;

        public override ushort MessageID => ProtocolId;

        public MountClientData MountData { get; set; }
        public MountDataMessage() { }

        public MountDataMessage( MountClientData MountData ){
            this.MountData = MountData;
        }

        public override void Serialize(IDataWriter writer)
        {
            MountData.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountData = new MountClientData();
            MountData.Deserialize(reader);
        }
    }
}
