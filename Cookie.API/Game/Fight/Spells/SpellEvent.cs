using System;

namespace Cookie.API.Game.Fight.Spells
{
    public class SpellCastEvent : EventArgs
    {
        public SpellCastEvent(int id, bool s)
        {
            SpellId = id;
            Sucess = s;
        }

        public int SpellId { get; set; }
        public bool Sucess { get; set; }
    }
}