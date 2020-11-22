using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Game.World.Pathfinding.Positions;

namespace Cookie.API.Game.World.Pathfinding
{
    public class MapMovementAdapter
    {
        public enum MovementTypeEnum
        {
            Mounted,
            Parable,
            Running,
            Slide,
            Walking
        }

        // Methods
        public static MovementPath GetClientMovement(List<uint> Keys)
        {
            var path = new MovementPath();
            PathElement element = null;
            var num = 0;
            var num2 = 0;
            foreach (int num2_loopVariable in Keys)
            {
                num2 = num2_loopVariable;
                var point = new MapPoint(num2 & 4095);
                var item = new PathElement {Cell = point};
                if (num == 0)
                    path.CellStart = point;
                else
                    element.Orientation = element.Cell.OrientationTo(item.Cell);
                if (num == Keys.Count - 1)
                    path.CellEnd = point;
                path.Cells.Add(item);
                element = item;
                num += 1;
            }
            return path;
        }

        public static List<uint> GetServerMovement(MovementPath Path)
        {
            var list = new List<uint>();
            var orientation = 0;
            foreach (var element in Path.Cells)
            {
                orientation = element.Orientation;
                list.Add(Convert.ToUInt32(((orientation & 7) << 12) | (element.Cell.CellId & 4095)));
            }
            list.Add(Convert.ToUInt32(((orientation & 7) << 12) | (Path.CellEnd.CellId & 4095)));
            return list;
        }

        public static int GetVelocity(PathElement cell, MovementTypeEnum moveType)
        {
            if (cell.Orientation % 2 == 0)
            {
                if (cell.Orientation % 4 == 0)
                    switch (moveType)
                    {
                        case MovementTypeEnum.Mounted:
                            return 200;
                        case MovementTypeEnum.Parable:
                            return 500;
                        case MovementTypeEnum.Running:
                            return 255;
                        case MovementTypeEnum.Slide:
                            return 255 * 3;
                        case MovementTypeEnum.Walking:
                            return 510;
                    }

                switch (moveType)
                {
                    case MovementTypeEnum.Mounted:
                        return 120;
                    case MovementTypeEnum.Parable:
                        return 450;
                    case MovementTypeEnum.Running:
                        return 150;
                    case MovementTypeEnum.Slide:
                        return 150 * 3;
                    case MovementTypeEnum.Walking:
                        return 425;
                }
            }

            switch (moveType)
            {
                case MovementTypeEnum.Mounted:
                    return 135;
                case MovementTypeEnum.Parable:
                    return 400;
                case MovementTypeEnum.Running:
                    return 170;
                case MovementTypeEnum.Slide:
                    return 170 * 3;
                case MovementTypeEnum.Walking:
                    return 480;
            }
            return 0;
        }

        public static int GetPathVelocity(MovementPath path, MovementTypeEnum moveType)
        {
            return path.Cells.Sum(cell => GetVelocity(cell, moveType));
        }
    }
}