using Cookie.API.Gamedata;

namespace Cookie.Core.Scripts
{
    public enum SpellTarget
    {
        Self,
        Enemy,
        Ally
    }

    public class IASpell
    {
        public bool HandToHand { get; }
        public bool MoveFirst { get; set; }
        public int Relaunchs { get; }
        public int SpellId { get; }
        public SpellTarget Target { get; }
        public string Name { get; }

        public IASpell(int spellId, int relaunchs, SpellTarget target, bool handToHand, bool moveFirst)
        {
            SpellId = spellId;
            Relaunchs = relaunchs;
            Target = target;
            HandToHand = handToHand;
            MoveFirst = moveFirst;
            Name = D2OParsing.GetSpellName(SpellId);
        }
    }
}