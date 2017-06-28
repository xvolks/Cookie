using System;
using System.Drawing;

namespace Cookie.API.Game.Map
{
    public class CellMovementEventArgs : EventArgs
    {
        public int StartCell { get; private set; }
        public int EndCell { get; private set; }
        public bool Sucess { get; private set; }

        public CellMovementEventArgs(int sc, int ec, bool s)
        {
            StartCell = sc;
            EndCell = ec;
            Sucess = s;
        }
    }

    public class MapChangementFinishedEventArgs : EventArgs
    {
        public int OldMap { get; private set; }
        public int NewMap { get; private set; }
        public bool Success { get; private set; }

        public MapChangementFinishedEventArgs(int om, int nm, bool s)
        {
            OldMap = om;
            NewMap = nm;
            Success = s;
        }
    }

    public class MapChangedEventArgs : EventArgs
    {
        public int NewMapId { get; private set; }

        public MapChangedEventArgs(int id)
        {
            NewMapId = id;
        }
    }
}
