using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
    {
        public new const ushort ProtocolId = 6599;

        public JobExperienceOtherPlayerUpdateMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public JobExperienceOtherPlayerUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }
    }
}