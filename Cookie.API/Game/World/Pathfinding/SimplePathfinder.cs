using System;
using System.Collections.Generic;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.World.Pathfinding.Positions;

namespace Cookie.API.Game.World.Pathfinding
{
    public class SimplePathfinder
    {
        private readonly List<SimpleCellInfo> list_0 = new List<SimpleCellInfo>();
        private readonly List<SimpleCellInfo> list_1 = new List<SimpleCellInfo>();
        private readonly List<int> ListCellIdFighters = new List<int>();
        private readonly Gamedata.D2p.Map MapData;
        private bool IsInFight;
        private MapPoint MapPoint_FromCell;
        private MapPoint MapPoint_ToCell;

        private int v_MouvementPoints = -1;

        public SimplePathfinder(Gamedata.D2p.Map Map)
        {
            MapData = Map;
            if (Map.Id == 2561)
                ListCellIdFighters.Add(53);
        }

        public MovementPath FindPath(int FromCell, int ToCell)
        {
            SimpleCellInfo class3 = null;
            MapPoint_FromCell = new MapPoint(FromCell);
            MapPoint_ToCell = new MapPoint(ToCell);
            var item = new SimpleCellInfo(MapPoint_FromCell);
            list_0.Add(item);
            Label_00BF:
            class3 = method_0();
            if (class3 != null)
            {
                list_0.Remove(class3);
                list_1.Add(class3);
                if (class3.v_OriginPoint.CellId == ToCell)
                    return method_3(class3);
                foreach (var point in class3.method_0(IsInFight))
                    if (Convert.ToBoolean(method_2(point.CellId)))
                        method_1(new SimpleCellInfo(MapData, point, class3, MapPoint_ToCell));
                goto Label_00BF;
            }
            return null;
        }

        private SimpleCellInfo method_0()
        {
            SimpleCellInfo class2 = null;
            foreach (var class3 in list_0)
                if (class2 == null || class2.int_0 + class2.int_1 > class3.int_0 + class3.int_1)
                    class2 = class3;
            return class2;
        }

        private void method_1(SimpleCellInfo class13_0)
        {
            foreach (var class2 in list_0)
                if (class2.v_OriginPoint.CellId == class13_0.v_OriginPoint.CellId &&
                    class2.int_0 + class2.int_1 <= class13_0.int_0 + class13_0.int_1)
                    return;
            foreach (var class3 in list_1)
                if (class3.v_OriginPoint.CellId == class13_0.v_OriginPoint.CellId &&
                    class3.int_0 + class3.int_1 <= class13_0.int_0 + class13_0.int_1)
                    return;
            list_0.Add(class13_0);
        }

        private object method_2(int int_1)
        {
            if (MapPoint_FromCell.CellId == int_1 || MapPoint_ToCell.CellId == int_1)
                return true;
            if (ListCellIdFighters.Contains(int_1))
                return false;
            return MapData.Cells[int_1].Mov;
        }

        private MovementPath method_3(SimpleCellInfo class13_0)
        {
            var range = new List<MapPoint>();
            var class2 = class13_0;
            while (class2.v_OriginPoint.CellId != MapPoint_FromCell.CellId)
            {
                class2 = class2.class13_0;
                range.Add(class2.v_OriginPoint);
            }
            range.Reverse();
            range.Add(class13_0.v_OriginPoint);
            if (v_MouvementPoints != -1)
                range = range.GetRange(0, v_MouvementPoints + 1 > range.Count ? range.Count : v_MouvementPoints + 1);
            var path = new MovementPath {CellStart = MapPoint_FromCell, CellEnd = range[range.Count - 1]};
            var num = range.Count - 2;
            var i = 0;
            while (i <= num)
            {
                var item = new PathElement {Cell = range[i], Orientation = range[i].OrientationTo(range[i + 1])};
                path.Cells.Add(item);
                i += 1;
            }
            path.Compress();
            return path;
        }

        public void SetFight(List<IFighter> Fighters, int movementPoints)
        {
            foreach (var figher in Fighters)
                if (figher.IsAlive)
                    ListCellIdFighters.Add(figher.CellId);
            v_MouvementPoints = movementPoints;
            IsInFight = true;
        }
    }
}