using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5651;

        public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
        {
            ListEntry = listEntry;
        }

        public JobCrafterDirectoryAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public JobCrafterDirectoryListEntry ListEntry { get; set; }

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