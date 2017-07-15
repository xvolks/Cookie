using System;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Utils;

namespace Cookie.Game.Map
{
    public class MapChangement : IMapChangement
    {
        private readonly IAccount _account;
        private readonly int _oId;
        private ICellMovement _cellMovement;
        private Timer _timeoutTimer;

        public MapChangement(IAccount account, ICellMovement cm, int nid)
        {
            _account = account;
            _oId = account.Character.MapId;
            NewMap = nid;
            _cellMovement = cm;
            _timeoutTimer = new Timer(20000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
        }

        public int NewMap { get; }

        public void PerformChangement()
        {
            if (_cellMovement == null || NewMap == 0)
            {
                OnChangementFinished(false);
                return;
            }

            _cellMovement.MovementFinished += _cellMovement_MovementFinished;
            _cellMovement.PerformMovement();
            _timeoutTimer.Start();
        }

        public event EventHandler<MapChangementFinishedEventArgs> ChangementFinished;
        public event Action Timeout;

        private void _timeoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeoutTimer.Stop();
            Logger.Default.Log("[MapChangement] Timeout.");
            OnChangementFinished(false);
        }

        private void Map_MapChanged(object sender, MapChangedEventArgs e)
        {
            _account.Character.Map.MapChanged -= Map_MapChanged;
            OnChangementFinished(e.NewMapId == NewMap);
        }

        private void _cellMovement_MovementFinished(object sender, CellMovementEventArgs e)
        {
            _cellMovement.MovementFinished -= _cellMovement_MovementFinished;
            _cellMovement = null;

            if (!e.Sucess)
            {
                OnChangementFinished(false);
                return;
            }

            _account.Character.Map.MapChanged += Map_MapChanged;
            _account.Network.SendToServer(new ChangeMapMessage(NewMap));
        }

        private void OnTimeout()
        {
            RemoveEvents();

            Timeout?.Invoke();
        }

        private void OnChangementFinished(bool s)
        {
            RemoveEvents();

            ChangementFinished?.Invoke(this, new MapChangementFinishedEventArgs(_oId, NewMap, s));
        }

        private void RemoveEvents()
        {
            _account.Character.Map.MapChanged -= Map_MapChanged;
            if (_cellMovement != null)
            {
                _cellMovement.MovementFinished -= _cellMovement_MovementFinished;
                _cellMovement = null;
            }
            _timeoutTimer.Stop();
            _timeoutTimer.Dispose();
            _timeoutTimer = null;
        }
    }
}