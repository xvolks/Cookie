﻿using System;

namespace Cookie.API.Game.Map
{
    public class CellMovementEventArgs : EventArgs
    {
        public CellMovementEventArgs(int sc, int ec, bool s, int d)
        {
            StartCell = sc;
            EndCell = ec;
            Sucess = s;
            Distance = d;
        }

        public int StartCell { get; }
        public int EndCell { get; }
        public bool Sucess { get; }
        public int Distance { get; }
    }

    public class MapChangementFinishedEventArgs : EventArgs
    {
        public MapChangementFinishedEventArgs(double om, double nm, bool s)
        {
            OldMap = om;
            NewMap = nm;
            Success = s;
        }

        public double OldMap { get; }
        public double NewMap { get; }
        public bool Success { get; }
    }

    public class MapChangedEventArgs : EventArgs
    {
        public MapChangedEventArgs(double id)
        {
            NewMapId = id;
        }

        public double NewMapId { get; }
    }
}