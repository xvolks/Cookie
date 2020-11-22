﻿using System;

namespace Cookie.API.Game.Fight.Spells
{
    public interface ISpellCast
    {
        int SpellId { get; }
        int CellId { get; }
        void PerformCast();
    }
}