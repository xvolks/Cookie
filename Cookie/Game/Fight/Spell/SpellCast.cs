using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.Fight.Spells;
using Cookie.API.Protocol;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Fight.Spell
{
    public class SpellCast : ISpellCast
    {
        private readonly IAccount _account;
        public SpellCast(IAccount account, int spellId, IFighter fighter)
        {
            _account = account;
            SpellId = spellId;
            CellId = fighter.CellId;
            Fighter = fighter;
        }

        public int SpellId { get; }
        public int CellId { get; }
        public IFighter Fighter { get; }
        public void PerformCast()
        {
            if (Fighter == null)
                return;
            if (SpellId == 0)
                _account.Network.SendToServer(new GameActionFightCastRequestMessage((ushort)SpellId, (short)Fighter.CellId));
            else
                _account.Network.SendToServer(new GameActionFightCastOnTargetRequestMessage((ushort)SpellId, Fighter.Id));
        }
    }
}