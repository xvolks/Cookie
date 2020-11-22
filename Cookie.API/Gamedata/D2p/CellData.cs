﻿using Cookie.API.Utils.IO;
using System.Collections.Generic;

namespace Cookie.API.Gamedata.D2p
{
    public class CellData
    {
        public int Arrow;
        public bool Blue;
        public bool FarmCell;
        public int Floor;
        public bool HavenbagCell;
        public bool Los;
        public int Losmov = 3;
        public int MapChangeData;
        public bool Mov;
        public uint MoveZone;
        public bool NonWalkableDuringFight;
        public bool NonWalkableDuringRP;
        public bool Red;
        public int Speed;
        public bool Visible;
        public byte LinkedZone;
        public List<int> TopArrowCell, BottomArrowCell, RightArrowCell, LeftArrowCell = new List<int>();

        // Methods
        internal void Init(IDataReader Reader, int MapVersion, int CellId, Map Parent)
        {
            Floor = Reader.ReadSByte() * 10;
            if (Floor != -1280)
            {
                bool topArrow, bottomArrow, rightArrow, leftArrow;

                if (MapVersion >= 9)
                {
                    int temp = Reader.ReadShort();
                    Mov = (temp & 1) == 0;
                    NonWalkableDuringFight = (temp & 2) != 0;
                    NonWalkableDuringRP = (temp & 4) != 0;
                    Los = (temp & 8) == 0;
                    Blue = (temp & 16) != 0;
                    Red = (temp & 32) != 0;
                    Visible = (temp & 64) != 0;
                    FarmCell = (temp & 128) != 0;
                    if (MapVersion >= 10)
                    {
                        HavenbagCell = (temp & 256) != 0;
                        topArrow = (temp & 512) != 0;
                        bottomArrow = (temp & 1024) != 0;
                        rightArrow = (temp & 2048) != 0;
                        leftArrow = (temp & 4096) != 0;
                    }
                    else
                    {
                        topArrow = (temp & 256) != 0;
                        bottomArrow = (temp & 512) != 0;
                        rightArrow = (temp & 1024) != 0;
                        leftArrow = (temp & 2048) != 0;
                    }
                    if (topArrow)
                        Parent.TopArrowCell.Add(CellId);
                    if (bottomArrow)
                        Parent.BottomArrowCell.Add(CellId);
                    if (rightArrow)
                        Parent.RightArrowCell.Add(CellId);
                    if (leftArrow)
                        Parent.LeftArrowCell.Add(CellId);
                }
                else
                {
                    Losmov = Reader.ReadByte();
                    Los = (Losmov & 2) >> 1 == 1;
                    Mov = (Losmov & 1) == 1;
                    Visible = (Losmov & 64) >> 6 == 1;
                    FarmCell = (Losmov & 32) >> 5 == 1;
                    Blue = (Losmov & 16) >> 4 == 1;
                    Red = (Losmov & 8) >> 3 == 1;
                    NonWalkableDuringRP = (Losmov & 128) >> 7 == 1;
                    NonWalkableDuringFight = (Losmov & 4) >> 2 == 1;
                }

                Speed = Reader.ReadSByte();
                MapChangeData = Reader.ReadSByte();
                //Console.WriteLine(MapChangeData);

                if (MapVersion > 5)
                    MoveZone = Reader.ReadByte();
                if (MapVersion > 10 && (HasLinkedZoneRP() || HasLinkedZoneFight()))
                    LinkedZone = Reader.ReadByte();
                if (MapVersion > 7 && MapVersion < 9)
                {
                    sbyte tmpBits = Reader.ReadSByte();
                    Arrow = 15 & tmpBits;
                }
            }
        }
        private bool HasLinkedZoneRP()
        {
            return Mov & !(FarmCell);
        }
        private bool HasLinkedZoneFight()
        {
            return Mov & !NonWalkableDuringFight & !FarmCell & !HavenbagCell;
        }
        private bool UseTopArrow()
        {
            if ((Arrow & 1) == 0)
                return false;
            return true;
        }
        private bool UseBottomArrow()
        {
            if ((Arrow & 2) == 0)
                return false;
            return true;
        }
        private bool UseRightArrow()
        {
            if ((Arrow & 3) == 0)
                return false;
            return true;
        }
        private bool UseLeftArrow()
        {
            if ((Arrow & 4) == 0)
                return false;
            return true;
        }
    }
}