using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ActorRestrictionsInformations : NetworkType
    {
        public const short ProtocolId = 204;
        public override short TypeId { get { return ProtocolId; } }

        public bool CantBeAggressed = false;
        public bool CantBeChallenged = false;
        public bool CantTrade = false;
        public bool CantBeAttackedByMutant = false;
        public bool CantRun = false;
        public bool ForceSlowWalk = false;
        public bool CantMinimize = false;
        public bool CantMove = false;
        public bool CantAggress = false;
        public bool CantChallenge = false;
        public bool CantExchange = false;
        public bool CantAttack = false;
        public bool CantChat = false;
        public bool CantBeMerchant = false;
        public bool CantUseObject = false;
        public bool CantUseTaxCollector = false;
        public bool CantUseInteractive = false;
        public bool CantSpeakToNPC = false;
        public bool CantChangeZone = false;
        public bool CantAttackMonster = false;
        public bool CantWalk8Directions = false;

        public ActorRestrictionsInformations()
        {
        }

        public ActorRestrictionsInformations(
            bool cantBeAggressed,
            bool cantBeChallenged,
            bool cantTrade,
            bool cantBeAttackedByMutant,
            bool cantRun,
            bool forceSlowWalk,
            bool cantMinimize,
            bool cantMove,
            bool cantAggress,
            bool cantChallenge,
            bool cantExchange,
            bool cantAttack,
            bool cantChat,
            bool cantBeMerchant,
            bool cantUseObject,
            bool cantUseTaxCollector,
            bool cantUseInteractive,
            bool cantSpeakToNPC,
            bool cantChangeZone,
            bool cantAttackMonster,
            bool cantWalk8Directions
        )
        {
            CantBeAggressed = cantBeAggressed;
            CantBeChallenged = cantBeChallenged;
            CantTrade = cantTrade;
            CantBeAttackedByMutant = cantBeAttackedByMutant;
            CantRun = cantRun;
            ForceSlowWalk = forceSlowWalk;
            CantMinimize = cantMinimize;
            CantMove = cantMove;
            CantAggress = cantAggress;
            CantChallenge = cantChallenge;
            CantExchange = cantExchange;
            CantAttack = cantAttack;
            CantChat = cantChat;
            CantBeMerchant = cantBeMerchant;
            CantUseObject = cantUseObject;
            CantUseTaxCollector = cantUseTaxCollector;
            CantUseInteractive = cantUseInteractive;
            CantSpeakToNPC = cantSpeakToNPC;
            CantChangeZone = cantChangeZone;
            CantAttackMonster = cantAttackMonster;
            CantWalk8Directions = cantWalk8Directions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, CantBeAggressed);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, CantBeChallenged);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, CantTrade);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, CantBeAttackedByMutant);
            box0 = BooleanByteWrapper.SetFlag(box0, 5, CantRun);
            box0 = BooleanByteWrapper.SetFlag(box0, 6, ForceSlowWalk);
            box0 = BooleanByteWrapper.SetFlag(box0, 7, CantMinimize);
            box0 = BooleanByteWrapper.SetFlag(box0, 8, CantMove);
            writer.WriteByte(box0);
            byte box1 = 0;
            box1 = BooleanByteWrapper.SetFlag(box1, 9, CantAggress);
            box1 = BooleanByteWrapper.SetFlag(box1, 10, CantChallenge);
            box1 = BooleanByteWrapper.SetFlag(box1, 11, CantExchange);
            box1 = BooleanByteWrapper.SetFlag(box1, 12, CantAttack);
            box1 = BooleanByteWrapper.SetFlag(box1, 13, CantChat);
            box1 = BooleanByteWrapper.SetFlag(box1, 14, CantBeMerchant);
            box1 = BooleanByteWrapper.SetFlag(box1, 15, CantUseObject);
            box1 = BooleanByteWrapper.SetFlag(box1, 16, CantUseTaxCollector);
            writer.WriteByte(box1);
            byte box2 = 0;
            box2 = BooleanByteWrapper.SetFlag(box2, 17, CantUseInteractive);
            box2 = BooleanByteWrapper.SetFlag(box2, 18, CantSpeakToNPC);
            box2 = BooleanByteWrapper.SetFlag(box2, 19, CantChangeZone);
            box2 = BooleanByteWrapper.SetFlag(box2, 20, CantAttackMonster);
            box2 = BooleanByteWrapper.SetFlag(box2, 21, CantWalk8Directions);
            writer.WriteByte(box2);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            CantBeAggressed = BooleanByteWrapper.GetFlag(box0, 1);
            CantBeChallenged = BooleanByteWrapper.GetFlag(box0, 2);
            CantTrade = BooleanByteWrapper.GetFlag(box0, 3);
            CantBeAttackedByMutant = BooleanByteWrapper.GetFlag(box0, 4);
            CantRun = BooleanByteWrapper.GetFlag(box0, 5);
            ForceSlowWalk = BooleanByteWrapper.GetFlag(box0, 6);
            CantMinimize = BooleanByteWrapper.GetFlag(box0, 7);
            CantMove = BooleanByteWrapper.GetFlag(box0, 8);
            byte box1 = reader.ReadByte();
            CantAggress = BooleanByteWrapper.GetFlag(box1, 9);
            CantChallenge = BooleanByteWrapper.GetFlag(box1, 10);
            CantExchange = BooleanByteWrapper.GetFlag(box1, 11);
            CantAttack = BooleanByteWrapper.GetFlag(box1, 12);
            CantChat = BooleanByteWrapper.GetFlag(box1, 13);
            CantBeMerchant = BooleanByteWrapper.GetFlag(box1, 14);
            CantUseObject = BooleanByteWrapper.GetFlag(box1, 15);
            CantUseTaxCollector = BooleanByteWrapper.GetFlag(box1, 16);
            byte box2 = reader.ReadByte();
            CantUseInteractive = BooleanByteWrapper.GetFlag(box2, 17);
            CantSpeakToNPC = BooleanByteWrapper.GetFlag(box2, 18);
            CantChangeZone = BooleanByteWrapper.GetFlag(box2, 19);
            CantAttackMonster = BooleanByteWrapper.GetFlag(box2, 20);
            CantWalk8Directions = BooleanByteWrapper.GetFlag(box2, 21);
        }
    }
}