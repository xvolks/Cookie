using System;
using Cookie.API.Game.Fight;
using Cookie.API.Gamedata;

namespace Cookie.Game.Fight
{
    public class Spell : ISpell
    {
        public Spell(int id, int level)
        {
            Id = id;
            Level = level;
            Name = D2OParsing.GetSpellName(id);
        }
        public int Id { get; internal set; }
        public int Level { get; internal set; }
        public int Position { get; internal set; }
        public string Name { get; internal set; }
    }
}
