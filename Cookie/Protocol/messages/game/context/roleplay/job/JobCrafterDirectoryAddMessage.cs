using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5651;
        public override uint MessageID { get { return ProtocolId; } }

        public JobCrafterDirectoryListEntry ListEntry;

        public JobCrafterDirectoryAddMessage()
        {
        }

        public JobCrafterDirectoryAddMessage(
            JobCrafterDirectoryListEntry listEntry
        )
        {
            ListEntry = listEntry;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            ListEntry.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ListEntry = new JobCrafterDirectoryListEntry();
            ListEntry.Deserialize(reader);
        }
    }
}