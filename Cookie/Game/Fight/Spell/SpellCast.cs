using System;
using System.Collections.Generic;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.Fight.Spells;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Fight.Spell
{
    public class SpellCast : ISpellCast
    {
        private readonly IAccount _account;
        private Timer _timeoutTimer;
        public SpellCast(IAccount account, int spellId, IFighter fighter)
        {
            _account = account;
            SpellId = spellId;
            CellId = fighter.CellId;
            _timeoutTimer = new Timer(7000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
            Fighter = fighter;
        }

        public int SpellId { get; }

        public int CellId { get; }
        public IFighter Fighter { get; }
        public void PerformCast()
        {
            _account.Character.Fight.SpellCasted += Spell_Casted;
            _account.Character.Fight.CloseCombatCasted += Fight_CloseCombatCasted;
            if (Fighter == null)
            {
                OnSpellCasted(false);
                return;
            }
            if (SpellId == 0)
                _account.Network.SendToServer(new GameActionFightCastRequestMessage((ushort)SpellId, (short)Fighter.CellId));
            else
                _account.Network.SendToServer(new GameActionFightCastOnTargetRequestMessage((ushort)SpellId, Fighter.Id));
            _timeoutTimer.Start();
        }

        private void Fight_CloseCombatCasted(GameActionFightCloseCombatMessage message)
        {
            if (message.SourceId == _account.Character.Id)
                OnSpellCasted(true);
        }

        private void Spell_Casted(GameActionFightSpellCastMessage message)
        {
            if (message.SourceId == _account.Character.Id)
                OnSpellCasted(true);
        }

        public event EventHandler<SpellCastEvent> SpellCasted;

        public event Action Timeout;

        private void _timeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeoutTimer.Stop();
            _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
            _timeoutTimer = null;

            OnTimeOut();
        }

        private void OnTimeOut()
        {
            _account.Character.Status = CharacterStatus.None;
            RemoveEvents();
            Timeout?.Invoke();
            OnSpellCasted(false);
        }

        private void OnSpellCasted(bool s)
        {
            RemoveEvents();
            SpellCasted?.Invoke(this, new SpellCastEvent(SpellId, s));
        }

        private void RemoveEvents()
        {
            if (_timeoutTimer != null)
            {
                _timeoutTimer.Stop();
                _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
                _timeoutTimer = null;
            }
            _account.Character.Fight.SpellCasted -= Spell_Casted;
            _account.Character.Fight.CloseCombatCasted -= Fight_CloseCombatCasted;
        }
    }
}