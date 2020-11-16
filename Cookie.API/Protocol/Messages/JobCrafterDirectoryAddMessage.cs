using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5651;

        public override ushort MessageID => ProtocolId;

        public JobCrafterDirectoryListEntry ListEntry { get; set; }
        public JobCrafterDirectoryAddMessage() { }

        public JobCrafterDirectoryAddMessage( JobCrafterDirectoryListEntry ListEntry ){
            this.ListEntry = ListEntry;
        }

        public override void Serialize(IDataWriter writer)
        {
            ListEntry.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ListEntry = new JobCrafterDirectoryListEntry();
            ListEntry.Deserialize(reader);
        }
    }
}
