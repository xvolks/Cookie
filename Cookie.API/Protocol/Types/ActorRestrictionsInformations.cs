using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ActorRestrictionsInformations : NetworkType
    {
        public const ushort ProtocolId = 204;

        public override ushort TypeID => ProtocolId;

        public bool CantBeAggressed { get; set; }
        public bool CantBeChallenged { get; set; }
        public bool CantTrade { get; set; }
        public bool CantBeAttackedByMutant { get; set; }
        public bool CantRun { get; set; }
        public bool ForceSlowWalk { get; set; }
        public bool CantMinimize { get; set; }
        public bool CantMove { get; set; }
        public bool CantAggress { get; set; }
        public bool CantChallenge { get; set; }
        public bool CantExchange { get; set; }
        public bool CantAttack { get; set; }
        public bool CantChat { get; set; }
        public bool CantBeMerchant { get; set; }
        public bool CantUseObject { get; set; }
        public bool CantUseTaxCollector { get; set; }
        public bool CantUseInteractive { get; set; }
        public bool CantSpeakToNPC { get; set; }
        public bool CantChangeZone { get; set; }
        public bool CantAttackMonster { get; set; }
        public bool CantWalk8Directions { get; set; }
        public ActorRestrictionsInformations() { }

        public ActorRestrictionsInformations( bool CantBeAggressed, bool CantBeChallenged, bool CantTrade, bool CantBeAttackedByMutant, bool CantRun, bool ForceSlowWalk, bool CantMinimize, bool CantMove, bool CantAggress, bool CantChallenge, bool CantExchange, bool CantAttack, bool CantChat, bool CantBeMerchant, bool CantUseObject, bool CantUseTaxCollector, bool CantUseInteractive, bool CantSpeakToNPC, bool CantChangeZone, bool CantAttackMonster, bool CantWalk8Directions ){
            this.CantBeAggressed = CantBeAggressed;
            this.CantBeChallenged = CantBeChallenged;
            this.CantTrade = CantTrade;
            this.CantBeAttackedByMutant = CantBeAttackedByMutant;
            this.CantRun = CantRun;
            this.ForceSlowWalk = ForceSlowWalk;
            this.CantMinimize = CantMinimize;
            this.CantMove = CantMove;
            this.CantAggress = CantAggress;
            this.CantChallenge = CantChallenge;
            this.CantExchange = CantExchange;
            this.CantAttack = CantAttack;
            this.CantChat = CantChat;
            this.CantBeMerchant = CantBeMerchant;
            this.CantUseObject = CantUseObject;
            this.CantUseTaxCollector = CantUseTaxCollector;
            this.CantUseInteractive = CantUseInteractive;
            this.CantSpeakToNPC = CantSpeakToNPC;
            this.CantChangeZone = CantChangeZone;
            this.CantAttackMonster = CantAttackMonster;
            this.CantWalk8Directions = CantWalk8Directions;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, CantBeAggressed);
			flag = BooleanByteWrapper.SetFlag(1, flag, CantBeChallenged);
			flag = BooleanByteWrapper.SetFlag(2, flag, CantTrade);
			flag = BooleanByteWrapper.SetFlag(3, flag, CantBeAttackedByMutant);
			flag = BooleanByteWrapper.SetFlag(4, flag, CantRun);
			flag = BooleanByteWrapper.SetFlag(5, flag, ForceSlowWalk);
			flag = BooleanByteWrapper.SetFlag(6, flag, CantMinimize);
			flag = BooleanByteWrapper.SetFlag(7, flag, CantMove);
			writer.WriteByte(flag);
			flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, CantAggress);
			flag = BooleanByteWrapper.SetFlag(1, flag, CantChallenge);
			flag = BooleanByteWrapper.SetFlag(2, flag, CantExchange);
			flag = BooleanByteWrapper.SetFlag(3, flag, CantAttack);
			flag = BooleanByteWrapper.SetFlag(4, flag, CantChat);
			flag = BooleanByteWrapper.SetFlag(5, flag, CantBeMerchant);
			flag = BooleanByteWrapper.SetFlag(6, flag, CantUseObject);
			flag = BooleanByteWrapper.SetFlag(7, flag, CantUseTaxCollector);
			writer.WriteByte(flag);
			flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, CantUseInteractive);
			flag = BooleanByteWrapper.SetFlag(1, flag, CantSpeakToNPC);
			flag = BooleanByteWrapper.SetFlag(2, flag, CantChangeZone);
			flag = BooleanByteWrapper.SetFlag(3, flag, CantAttackMonster);
			flag = BooleanByteWrapper.SetFlag(4, flag, CantWalk8Directions);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			CantBeAggressed = BooleanByteWrapper.GetFlag(flag, 0);
			CantBeChallenged = BooleanByteWrapper.GetFlag(flag, 1);
			CantTrade = BooleanByteWrapper.GetFlag(flag, 2);
			CantBeAttackedByMutant = BooleanByteWrapper.GetFlag(flag, 3);
			CantRun = BooleanByteWrapper.GetFlag(flag, 4);
			ForceSlowWalk = BooleanByteWrapper.GetFlag(flag, 5);
			CantMinimize = BooleanByteWrapper.GetFlag(flag, 6);
			CantMove = BooleanByteWrapper.GetFlag(flag, 7);
			flag = reader.ReadByte();
			CantAggress = BooleanByteWrapper.GetFlag(flag, 0);
			CantChallenge = BooleanByteWrapper.GetFlag(flag, 1);
			CantExchange = BooleanByteWrapper.GetFlag(flag, 2);
			CantAttack = BooleanByteWrapper.GetFlag(flag, 3);
			CantChat = BooleanByteWrapper.GetFlag(flag, 4);
			CantBeMerchant = BooleanByteWrapper.GetFlag(flag, 5);
			CantUseObject = BooleanByteWrapper.GetFlag(flag, 6);
			CantUseTaxCollector = BooleanByteWrapper.GetFlag(flag, 7);
			flag = reader.ReadByte();
			CantUseInteractive = BooleanByteWrapper.GetFlag(flag, 0);
			CantSpeakToNPC = BooleanByteWrapper.GetFlag(flag, 1);
			CantChangeZone = BooleanByteWrapper.GetFlag(flag, 2);
			CantAttackMonster = BooleanByteWrapper.GetFlag(flag, 3);
			CantWalk8Directions = BooleanByteWrapper.GetFlag(flag, 4);
        }
    }
}
