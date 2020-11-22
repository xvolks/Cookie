using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6046;

        public override ushort MessageID => ProtocolId;

        public List<JobCrafterDirectoryListEntry> ListEntries { get; set; }
        public JobCrafterDirectoryListMessage() { }

        public JobCrafterDirectoryListMessage( List<JobCrafterDirectoryListEntry> ListEntries ){
            this.ListEntries = ListEntries;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ListEntries.Count);
			foreach (var x in ListEntries)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ListEntriesCount = reader.ReadShort();
            ListEntries = new List<JobCrafterDirectoryListEntry>();
            for (var i = 0; i < ListEntriesCount; i++)
            {
                var objectToAdd = new JobCrafterDirectoryListEntry();
                objectToAdd.Deserialize(reader);
                ListEntries.Add(objectToAdd);
            }
        }
    }
}
