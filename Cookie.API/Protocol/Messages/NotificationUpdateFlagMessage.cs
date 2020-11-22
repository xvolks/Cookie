using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NotificationUpdateFlagMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6090;

        public override ushort MessageID => ProtocolId;

        public ushort Index { get; set; }
        public NotificationUpdateFlagMessage() { }

        public NotificationUpdateFlagMessage( ushort Index ){
            this.Index = Index;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            Index = reader.ReadVarUhShort();
        }
    }
}
