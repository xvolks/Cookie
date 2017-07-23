using System;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Fight.Spells;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Fight;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Fight.Spell
{
    public class SpellCast : ISpellCast
    {
        private readonly IAccount _account;
        private Timer _timeoutTimer;

        public SpellCast(IAccount account, int spellId, int cellId)
        {
            _account = account;
            SpellId = spellId;
            CellId = cellId;
            _timeoutTimer = new Timer(20000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
        }

        public int SpellId { get; }

        public int CellId { get; }

        public void PerformCast()
        {
            _account.Character.Fight.SpellCasted += Spell_Casted;

            foreach (var fighter in _account.Character.Fight.GetMonsters())
            {
                if (fighter.CellId != CellId) continue;
                _account.Network.SendToServer(
                    new GameActionFightCastOnTargetRequestMessage((ushort) SpellId, fighter.Id));
                break;
            }
            _timeoutTimer.Start();
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
        }

        private void Spell_Casted(GameActionFightSpellCastMessage message)
        {
            if (message.SourceId == _account.Character.Id)
                OnSpellCasted(true);
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
        }
    }
}