using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareCreatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6668;

        public override ushort MessageID => ProtocolId;

        public DareInformations DareInfos { get; set; }
        public bool NeedNotifications { get; set; }
        public DareCreatedMessage() { }

        public DareCreatedMessage( DareInformations DareInfos, bool NeedNotifications ){
            this.DareInfos = DareInfos;
            this.NeedNotifications = NeedNotifications;
        }

        public override void Serialize(IDataWriter writer)
        {
            DareInfos.Serialize(writer);
            writer.WriteBoolean(NeedNotifications);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareInfos = new DareInformations();
            DareInfos.Deserialize(reader);
            NeedNotifications = reader.ReadBoolean();
        }
    }
}
