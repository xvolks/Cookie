using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6043;

        public JobCrafterDirectoryEntryRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public JobCrafterDirectoryEntryRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
        }
    }
}