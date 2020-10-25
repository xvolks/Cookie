using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightJoinMessage : NetworkMessage
    {
        public const uint ProtocolId = 702;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsTeamPhase = false;
        public bool CanBeCancelled = false;
        public bool CanSayReady = false;
        public bool IsFightStarted = false;
        public short TimeMaxBeforeFightStart = 0;
        public byte FightType = 0;

        public GameFightJoinMessage()
        {
        }

        public GameFightJoinMessage(
            bool isTeamPhase,
            bool canBeCancelled,
            bool canSayReady,
            bool isFightStarted,
            short timeMaxBeforeFightStart,
            byte fightType
        )
        {
            IsTeamPhase = isTeamPhase;
            CanBeCancelled = canBeCancelled;
            CanSayReady = canSayReady;
            IsFightStarted = isFightStarted;
            TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
            FightType = fightType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsTeamPhase);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, CanBeCancelled);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, CanSayReady);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, IsFightStarted);
            writer.WriteByte(box0);
            writer.WriteShort(TimeMaxBeforeFightStart);
            writer.WriteByte(FightType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsTeamPhase = BooleanByteWrapper.GetFlag(box0, 1);
            CanBeCancelled = BooleanByteWrapper.GetFlag(box0, 2);
            CanSayReady = BooleanByteWrapper.GetFlag(box0, 3);
            IsFightStarted = BooleanByteWrapper.GetFlag(box0, 4);
            TimeMaxBeforeFightStart = reader.ReadShort();
            FightType = reader.ReadByte();
        }
    }
}