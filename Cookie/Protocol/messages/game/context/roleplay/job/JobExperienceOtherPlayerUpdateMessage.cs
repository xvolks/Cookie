using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
    {
        public new const uint ProtocolId = 6599;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public JobExperienceOtherPlayerUpdateMessage(): base()
        {
        }

        public JobExperienceOtherPlayerUpdateMessage(
            JobExperience experiencesUpdate,
            long playerId
        ): base(
            experiencesUpdate
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
        }
    }
}