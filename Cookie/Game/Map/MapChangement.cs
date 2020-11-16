using System;
using System.Threading.Tasks;
using System.Timers;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;

namespace Cookie.Game.Map
{
    public class MapChangement : IMapChangement
    {
        private readonly IAccount _account;
        private readonly double _oId;
        private ICellMovement _cellMovement;
        private Timer _timeoutTimer;

        public MapChangement(IAccount account, ICellMovement cm, int nid)
        {
            _account = account;
            _oId = account.Character.MapId;
            NewMap = nid;
            _cellMovement = cm;
            _timeoutTimer = new Timer(10000);
            _timeoutTimer.Elapsed += _timeoutTimer_Elapsed;
        }

        public int NewMap { get; }

        public void PerformChangement()
        {
            if (_timeoutTimer.Enabled)
                return;
            if (_cellMovement == null || NewMap == 0)
            {
                OnChangementFinished(false);
                return;
            }
            _account.Character.Map.MovementConfirmed += Map_MovementConfirmed;
            _cellMovement.PerformMovement();
            if (_timeoutTimer != null) //if null it means it timedout
                _timeoutTimer.Start();
        }

        private void Map_MovementConfirmed(object sender, MovementConfirmed e)
        {
            _account.Character.Map.MovementConfirmed -= Map_MovementConfirmed;
            _cellMovement = null;

            if (!e.Status)
            {
                OnChangementFinished(false);
                return;
            }

            _account.Character.Map.MapChanged += Map_MapChanged;
            Console.WriteLine($"Sending ChangeMapMessage");
            Task.Delay(150).ContinueWith(t =>
            _account.Network.SendToServer(new ChangeMapMessage(NewMap, false))
            );
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
                _cellMovement = null;
            }
            if(_timeoutTimer != null)
            {
                _timeoutTimer.Stop();
                _timeoutTimer.Dispose();
                _timeoutTimer = null;
            }
        }
    }
}