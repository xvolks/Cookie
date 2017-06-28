using System;
using System.Linq;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Map
{
    public class CellMovement : ICellMovement
    {
        private readonly MovementPath _path;
        private readonly IAccount _account;
        private Timer _timeoutTimer;

        public int EndCell { get; }

        public int StartCell { get; }

        public CellMovement(IAccount account, MovementPath mp)
        {
            _account = account;
            StartCell = mp.CellStart.CellId;
            EndCell = mp.CellEnd.CellId;
            _path = mp;
            _timeoutTimer = new Timer(20000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
        }

        private void _timeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeoutTimer.Stop();
            _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
            _timeoutTimer = null;

            OnTimeOut();
        }

        public void PerformMovement()
        {
            if (_path == null || _path.Cells.Count == 0)
            {
                OnMovementFinished(false);
                return;
            }
            
            var keys = MapMovementAdapter.GetServerMovement(_path).Select(f => (short) f).ToList();

            _account.Character.Map.MovementFailed += Map_MovementFailed;
            _account.Character.Map.MapMovement += Map_MapMovement;

            _account.Network.SendToServer(new GameMapMovementRequestMessage(keys, _account.Character.MapId));
            _timeoutTimer.Start();
        }

        private void Map_MapMovement(GameMapMovementMessage message)
        {
            if (message.ActorId != _account.Character.Id || message.KeyMovements[0] != _path.CellStart.CellId) return;
            _account.Character.Map.MapMovement -= Map_MapMovement;
            _account.Character.Status = CharacterStatus.Moving;

            MovementVelocity.MovementTypeEnum type;
            if (_path.Cells.Count >= 4) // Need check pods
                type = MovementVelocity.MovementTypeEnum.WALKING;
            else
                type = MovementVelocity.MovementTypeEnum.RUNNING;

            var time = MovementVelocity.GetPathVelocity(_path, type);
            _account.PerformAction(() =>
            {
                _account.Network.SendToServer(new GameMapMovementConfirmMessage());
                OnMovementFinished(true);
            }, (int) time);
        }

        private void Map_MovementConfirmed(object sender, EventArgs e) => OnMovementFinished(true);

        private void Map_MovementFailed(object sender, EventArgs e) => OnMovementFinished(false);

        public event EventHandler<CellMovementEventArgs> MovementFinished;

        public event Action Timeout;

        private void OnTimeOut()
        {
            _account.Character.Status = CharacterStatus.None;
            RemoveEvents();
            Timeout?.Invoke();
        }

        private void OnMovementFinished(bool s)
        {
            _account.Character.Status = CharacterStatus.None;
            RemoveEvents();
            MovementFinished?.Invoke(this, new CellMovementEventArgs(StartCell, EndCell, s));
        }

        private void RemoveEvents()
        {
            if (_timeoutTimer != null)
            {
                _timeoutTimer.Stop();
                _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
                _timeoutTimer = null;
            }
            _account.Character.Map.MovementFailed -= Map_MovementFailed;
            _account.Character.Map.MapMovement -= Map_MapMovement;
            _account.Character.Map.MovementConfirmed -= Map_MovementConfirmed;
        }
    }
}
