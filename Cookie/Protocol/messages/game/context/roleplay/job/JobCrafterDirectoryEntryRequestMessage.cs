using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryEntryRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6043;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public JobCrafterDirectoryEntryRequestMessage()
        {
        }

        public JobCrafterDirectoryEntryRequestMessage(
            long playerId
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
        }
    }
}