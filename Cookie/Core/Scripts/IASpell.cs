namespace Cookie.Core.Scripts
{
    public enum SpellTarget { Self, Enemy, Ally }
    public class IASpell
    {
        public SpellTarget Target;
        public int SpellId;
        public int Relaunchs;
        public bool Condition;

        public IASpell(int spellId, int relaunchs, SpellTarget target = SpellTarget.Enemy, bool condition = true)
        {
            SpellId = spellId;
            Relaunchs = relaunchs;
            Target = target;
            Condition = condition;
        }
    }
}
