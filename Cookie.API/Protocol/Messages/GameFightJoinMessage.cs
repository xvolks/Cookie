using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightJoinMessage : NetworkMessage
    {
        public const ushort ProtocolId = 702;

        public override ushort MessageID => ProtocolId;

        public bool IsTeamPhase { get; set; }
        public bool CanBeCancelled { get; set; }
        public bool CanSayReady { get; set; }
        public bool IsFightStarted { get; set; }
        public short TimeMaxBeforeFightStart { get; set; }
        public sbyte FightType { get; set; }
        public GameFightJoinMessage() { }

        public GameFightJoinMessage( bool IsTeamPhase, bool CanBeCancelled, bool CanSayReady, bool IsFightStarted, short TimeMaxBeforeFightStart, sbyte FightType ){
            this.IsTeamPhase = IsTeamPhase;
            this.CanBeCancelled = CanBeCancelled;
            this.CanSayReady = CanSayReady;
            this.IsFightStarted = IsFightStarted;
            this.TimeMaxBeforeFightStart = TimeMaxBeforeFightStart;
            this.FightType = FightType;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsTeamPhase);
			flag = BooleanByteWrapper.SetFlag(1, flag, CanBeCancelled);
			flag = BooleanByteWrapper.SetFlag(2, flag, CanSayReady);
			flag = BooleanByteWrapper.SetFlag(3, flag, IsFightStarted);
			writer.WriteByte(flag);
            writer.WriteShort(TimeMaxBeforeFightStart);
            writer.WriteSByte(FightType);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsTeamPhase = BooleanByteWrapper.GetFlag(flag, 0);;
			CanBeCancelled = BooleanByteWrapper.GetFlag(flag, 1);;
			CanSayReady = BooleanByteWrapper.GetFlag(flag, 2);;
			IsFightStarted = BooleanByteWrapper.GetFlag(flag, 3);;
            TimeMaxBeforeFightStart = reader.ReadShort();
            FightType = reader.ReadSByte();
        }
    }
}
