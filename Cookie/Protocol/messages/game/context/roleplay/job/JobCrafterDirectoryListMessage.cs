using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6046;
        public override uint MessageID { get { return ProtocolId; } }

        public List<JobCrafterDirectoryListEntry> ListEntries;

        public JobCrafterDirectoryListMessage()
        {
        }

        public JobCrafterDirectoryListMessage(
            List<JobCrafterDirectoryListEntry> listEntries
        )
        {
            ListEntries = listEntries;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ListEntries.Count());
            foreach (var current in ListEntries)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countListEntries = reader.ReadShort();
            ListEntries = new List<JobCrafterDirectoryListEntry>();
            for (short i = 0; i < countListEntries; i++)
            {
                JobCrafterDirectoryListEntry type = new JobCrafterDirectoryListEntry();
                type.Deserialize(reader);
                ListEntries.Add(type);
            }
        }
    }
}