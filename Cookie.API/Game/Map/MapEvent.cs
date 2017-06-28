using System;

namespace Cookie.API.Game.Map
{
    public class CellMovementEventArgs : EventArgs
    {
        public CellMovementEventArgs(int sc, int ec, bool s)
        {
            StartCell = sc;
            EndCell = ec;
            Sucess = s;
        }

        public int StartCell { get; }
        public int EndCell { get; }
        public bool Sucess { get; }
    }

    public class MapChangementFinishedEventArgs : EventArgs
    {
        public MapChangementFinishedEventArgs(int om, int nm, bool s)
        {
            OldMap = om;
            NewMap = nm;
            Success = s;
        }

        public int OldMap { get; }
        public int NewMap { get; }
        public bool Success { get; }
    }

    public class MapChangedEventArgs : EventArgs
    {
        public MapChangedEventArgs(int id)
        {
            NewMapId = id;
        }

        public int NewMapId { get; }
    }
}