using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AcquaintanceOnlineInformation : AcquaintanceInformation
    {
        public new const short ProtocolId = 562;
        public override short TypeId { get { return ProtocolId; } }

        public long PlayerId = 0;
        public string PlayerName;
        public short MoodSmileyId = 0;
        public PlayerStatus Status;

        public AcquaintanceOnlineInformation(): base()
        {
        }

        public AcquaintanceOnlineInformation(
            int accountId,
            string accountName,
            byte playerState,
            long playerId,
            string playerName,
            short moodSmileyId,
            PlayerStatus status
        ): base(
            accountId,
            accountName,
            playerState
        )
        {
            PlayerId = playerId;
            PlayerName = playerName;
            MoodSmileyId = moodSmileyId;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarShort(MoodSmileyId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            MoodSmileyId = reader.ReadVarShort();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}