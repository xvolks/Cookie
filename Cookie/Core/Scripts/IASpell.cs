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
        public bool Condition;
        public int Relaunchs;
        public int SpellId;
        public SpellTarget Target;

        public IASpell(int spellId, int relaunchs, SpellTarget target = SpellTarget.Enemy, bool condition = true)
        {
            SpellId = spellId;
            Relaunchs = relaunchs;
            Target = target;
            Condition = condition;
        }
    }
}