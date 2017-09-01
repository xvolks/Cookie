using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightJoinMessage : NetworkMessage
    {
        public const ushort ProtocolId = 702;

        public GameFightJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady, bool isFightStarted,
            short timeMaxBeforeFightStart, byte fightType)
        {
            IsTeamPhase = isTeamPhase;
            CanBeCancelled = canBeCancelled;
            CanSayReady = canSayReady;
            IsFightStarted = isFightStarted;
            TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
            FightType = fightType;
        }

        public GameFightJoinMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool IsTeamPhase { get; set; }
        public bool CanBeCancelled { get; set; }
        public bool CanSayReady { get; set; }
        public bool IsFightStarted { get; set; }
        public short TimeMaxBeforeFightStart { get; set; }
        public byte FightType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, IsTeamPhase);
            flag = BooleanByteWrapper.SetFlag(1, flag, CanBeCancelled);
            flag = BooleanByteWrapper.SetFlag(2, flag, CanSayReady);
            flag = BooleanByteWrapper.SetFlag(3, flag, IsFightStarted);
            writer.WriteByte(flag);
            writer.WriteShort(TimeMaxBeforeFightStart);
            writer.WriteByte(FightType);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            IsTeamPhase = BooleanByteWrapper.GetFlag(flag, 0);
            CanBeCancelled = BooleanByteWrapper.GetFlag(flag, 1);
            CanSayReady = BooleanByteWrapper.GetFlag(flag, 2);
            IsFightStarted = BooleanByteWrapper.GetFlag(flag, 3);
            TimeMaxBeforeFightStart = reader.ReadShort();
            FightType = reader.ReadByte();
        }
    }
}