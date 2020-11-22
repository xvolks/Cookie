using System;
using System.Linq;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Map
{
    public class CellMovement : ICellMovement
    {
        private readonly IAccount _account;
        private readonly MovementPath _path;
        private Timer _timeoutTimer;

        public CellMovement(IAccount account, MovementPath mp)
        {
            _account = account;
            StartCell = mp.CellStart.CellId;
            EndCell = mp.CellEnd.CellId;
            _path = mp;
            _timeoutTimer = new Timer(20000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
        }

        public int EndCell { get; }

        public int StartCell { get; }

        public void PerformMovement()
        {
            if (_path == null || _path.Cells.Count == 0)
            {
                OnMovementFinished(false);
                return;
            }
            else if (StartCell == EndCell)
                OnMovementFinished(true);

            var keys = MapMovementAdapter.GetServerMovement(_path).Select(f => (short) f).ToList();

            _account.Character.Map.MovementFailed += Map_MovementFailed;
            _account.Character.Map.MapMovement += Map_MapMovement;//it doesnt confirm unfortunatelly.

            _account.Network.SendToServer(new GameMapMovementRequestMessage(keys, _account.Character.MapId));
            if (_timeoutTimer != null) //if null it means it timedout
                _timeoutTimer.Start();
        }

        public event EventHandler<CellMovementEventArgs> MovementFinished;

        public event Action Timeout;

        private void _timeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeoutTimer.Stop();
            _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
            _timeoutTimer = null;

            OnTimeOut();
        }

        private void Map_MapMovement(GameMapMovementMessage message)
        {
            if (message.ActorId != _account.Character.Id) return; // packet doesn't match the move requested.
            Console.WriteLine($"Receiving[GameMapMovementMessage] Destination {message.KeyMovements[message.KeyMovements.Count-1]}");
            _account.Character.Map.MapMovement -= Map_MapMovement;
            if (_account.Character.Status != CharacterStatus.Fighting)
                _account.PerformAction(() =>
                    {
                        _account.Network.SendToServer(new GameMapMovementConfirmMessage());
                        OnMovementFinished(true);
                    },
                    (int)MovementVelocity.GetPathVelocity(_path,
                        _path.Cells.Count >= 4
                            ? MovementVelocity.MovementTypeEnum.WALKING
                            : MovementVelocity.MovementTypeEnum.RUNNING));
            else
                OnMovementFinished(true);
        }

        private void Map_MovementFailed(object sender, EventArgs e)
        {
            OnMovementFinished(false);
        }

        private void OnTimeOut()
        {
            RemoveEvents();
            Timeout?.Invoke();
        }

        private void OnMovementFinished(bool s)
        {
            RemoveEvents();
            if (StartCell == EndCell)
                s = true;
            MovementFinished?.Invoke(this, new CellMovementEventArgs(StartCell, EndCell, s, _path.Cells.Count + 1));
        }

        private void RemoveEvents()
        {
            if (_timeoutTimer != null)
            {
                _timeoutTimer.Stop();
                _timeoutTimer.Elapsed -= _timeoutTimer_Elapsed;
                _timeoutTimer = null;
            }
            _account.Character.Map.MovementFailed -= Map_MovementFailed; // movement failed
            _account.Character.Map.MapMovement -= Map_MapMovement; // movement started
        }
    }
}