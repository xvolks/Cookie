using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
    {
        public new const uint ProtocolId = 6215;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameFightResumeSlaveInfo> SlavesInfo;

        public GameFightResumeWithSlavesMessage(): base()
        {
        }

        public GameFightResumeWithSlavesMessage(
            List<FightDispellableEffectExtendedInformations> effects,
            List<GameActionMark> marks,
            short gameTurn,
            int fightStart,
            List<Idol> idols,
            List<GameFightSpellCooldown> spellCooldowns,
            byte summonCount,
            byte bombCount,
            List<GameFightResumeSlaveInfo> slavesInfo
        ): base(
            effects,
            marks,
            gameTurn,
            fightStart,
            idols,
            spellCooldowns,
            summonCount,
            bombCount
        )
        {
            SlavesInfo = slavesInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)SlavesInfo.Count());
            foreach (var current in SlavesInfo)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countSlavesInfo = reader.ReadShort();
            SlavesInfo = new List<GameFightResumeSlaveInfo>();
            for (short i = 0; i < countSlavesInfo; i++)
            {
                GameFightResumeSlaveInfo type = new GameFightResumeSlaveInfo();
                type.Deserialize(reader);
                SlavesInfo.Add(type);
            }
        }
    }
}