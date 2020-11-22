using System;

namespace Cookie.API.Game.Map
{
    public interface ICellMovement
    {
        int StartCell { get; }
        int EndCell { get; }
        void PerformMovement();
        event EventHandler<CellMovementEventArgs> MovementFinished;
        event Action Timeout;
    }
}