namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using Utils.IO;

    public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
    {
        public new const ushort ProtocolId = 6599;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public JobExperienceOtherPlayerUpdateMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public JobExperienceOtherPlayerUpdateMessage() { }

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
