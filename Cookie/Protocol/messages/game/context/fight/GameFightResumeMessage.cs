using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public new const uint ProtocolId = 6067;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameFightSpellCooldown> SpellCooldowns;
        public byte SummonCount = 0;
        public byte BombCount = 0;

        public GameFightResumeMessage(): base()
        {
        }

        public GameFightResumeMessage(
            List<FightDispellableEffectExtendedInformations> effects,
            List<GameActionMark> marks,
            short gameTurn,
            int fightStart,
            List<Idol> idols,
            List<GameFightSpellCooldown> spellCooldowns,
            byte summonCount,
            byte bombCount
        ): base(
            effects,
            marks,
            gameTurn,
            fightStart,
            idols
        )
        {
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)SpellCooldowns.Count());
            foreach (var current in SpellCooldowns)
            {
                current.Serialize(writer);
            }
            writer.WriteByte(SummonCount);
            writer.WriteByte(BombCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countSpellCooldowns = reader.ReadShort();
            SpellCooldowns = new List<GameFightSpellCooldown>();
            for (short i = 0; i < countSpellCooldowns; i++)
            {
                GameFightSpellCooldown type = new GameFightSpellCooldown();
                type.Deserialize(reader);
                SpellCooldowns.Add(type);
            }
            SummonCount = reader.ReadByte();
            BombCount = reader.ReadByte();
        }
    }
}