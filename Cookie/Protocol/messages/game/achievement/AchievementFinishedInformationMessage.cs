using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementFinishedInformationMessage : AchievementFinishedMessage
    {
        public new const uint ProtocolId = 6381;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public long PlayerId = 0;

        public AchievementFinishedInformationMessage(): base()
        {
        }

        public AchievementFinishedInformationMessage(
            AchievementAchievedRewardable achievement,
            string name,
            long playerId
        ): base(
            achievement
        )
        {
            Name = name;
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            PlayerId = reader.ReadVarLong();
        }
    }
}