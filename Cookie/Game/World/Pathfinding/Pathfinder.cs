using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Cookie.Game.Map;
using Cookie.Gamedata.D2p;

namespace Cookie.Game.World.Pathfinding
{
    public class Pathfinder
    {
        #region Constructeurs

        #endregion

        #region Declarations

        private bool useDiagonals;
        private bool find;

        private Cell destinationCell, startCell;
        private MapData currentMap;

        private readonly CellMatrix matrix = new CellMatrix();
        private readonly CellList openList = new CellList();

        private const short MapWidth = 20;
        private const short MapHeight = 14;

        public int LoadedMapId => currentMap?.Data.Id ?? 0;

        #endregion

        #region Public method

        public void SetMap(MapData map, bool useDiagonal)
        {
            currentMap = map;
            useDiagonals = useDiagonal;
            matrix.Clear();
            openList.Clear();
            find = false;
            var id = 0;
            var loc1 = 0;
            var loc2 = 0;
            var loc3 = 0;
            for (var line = 0; line < 20; line++)
            {
                CellData cell;
                for (var column = 0; column < 14; column++)
                {
                    cell = currentMap.Data.Cells[id];
                    if (!map.NoEntitiesOnCell((short) id))
                        cell.Mov = false;
                    matrix.Add(id,
                        new Cell(cell.MapChangeData != 0, cell.Mov, true, column, loc3, id,
                            new Point(loc1 + column, loc2 + column)));
                    id++;
                }
                loc1++;
                loc3++;
                for (var column = 0; column < 14; column++)
                {
                    cell = currentMap.Data.Cells[id];
                    if (!map.NoEntitiesOnCell((short) id))
                        cell.Mov = false;
                    matrix.Add(id,
                        new Cell(cell.MapChangeData != 0, cell.Mov, true, column, loc3, id,
                            new Point(loc1 + column, loc2 + column)));
                    id++;
                }
                loc3++;
                loc2--;
            }
        }

        public short[] GetCompressedPath(short startCellId, short destinationCellId)
        {
            return PathingUtils.GetCompressedPath(Find(startCellId, destinationCellId)).ToArray();
        }

        public short[] GetCompressedPath(List<CellWithOrientation> cells) => PathingUtils.GetCompressedPath(cells);

        public List<CellWithOrientation> GetPath(short startCellId, short destinationCellId)
        {
            return Find(startCellId, destinationCellId);
        }

        #endregion

        #region Private method

        private List<CellWithOrientation> Find(short startCellId, short destinationCellId)
        {
            startCell = matrix[startCellId];
            destinationCell = matrix[destinationCellId];

            matrix[startCellId].Start = true;
            matrix[startCellId].InClosedList = true;

            matrix[destinationCellId].End = true;
            destinationCell = matrix[destinationCellId];
            foreach (var cell in matrix.Values)
                cell.SetH(matrix[destinationCellId]);

            var currentCell = matrix[startCellId];

            var startTime = Environment.TickCount;

            while (!find)
            {
                FindAvalableCell(currentCell);

                if (!find)
                {
                    if (openList.Count == 0)
                        return null;

                    currentCell = openList[0];
                    currentCell.InClosedList = true;
                    currentCell.InOpenList = false;
                    openList.RemoveAt(0);
                }

                if (Environment.TickCount - startTime > 500)
                    return null;
            }

            var cells = new List<CellWithOrientation>();
            currentCell = matrix[destinationCellId];

            while (currentCell.Parent != null)
            {
                cells.Insert(0,
                    new CellWithOrientation(currentCell.Id, currentCell.Location.X, currentCell.Location.Y));
                currentCell = currentCell.Parent;
            }
            cells.Insert(0,
                new CellWithOrientation(startCellId, matrix[startCellId].Location.X, matrix[startCellId].Location.Y));
            return cells;
        }

        private void FindAvalableCell(Cell cell)
        {
            Cell avalableCell;

            #region Haut-Droite

            if (cell.Position[0] == 0 && cell.Position[6] == 0)
            {
                avalableCell = cell.Pair ? matrix[cell.Id - 14] : matrix[cell.Id - 13];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Bas-Droite

            if (cell.Position[2] == 0 && cell.Position[6] == 0)
            {
                avalableCell = cell.Pair ? matrix[cell.Id + 14] : matrix[cell.Id + 15];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Haut-Gauche

            if (cell.Position[0] == 0 && cell.Position[4] == 0)
            {
                avalableCell = cell.Pair ? matrix[cell.Id - 15] : matrix[cell.Id - 14];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Bas-Gauche

            if (cell.Position[2] == 0 && cell.Position[4] == 0)
            {
                avalableCell = cell.Pair ? matrix[cell.Id + 13] : matrix[cell.Id + 14];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Droite

            if (cell.Position[6] == 0 && cell.Position[7] == 0 && useDiagonals)
            {
                avalableCell = matrix[cell.Id + 1];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Gauche

            if (cell.Position[4] == 0 && cell.Position[5] == 0 && useDiagonals)
            {
                avalableCell = matrix[cell.Id - 1];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Haut

            if (cell.Position[0] == 0 && cell.Position[1] == 0 && useDiagonals)
            {
                avalableCell = matrix[cell.Id - 28];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            #region Bas

            if (cell.Position[2] == 0 && cell.Position[3] == 0 && useDiagonals)
            {
                avalableCell = matrix[cell.Id + 28];
                if (avalableCell.End)
                {
                    avalableCell.Parent = cell;
                    find = true;
                    return;
                }

                if (avalableCell.Walkable)
                    if (!avalableCell.InOpenList && !avalableCell.InClosedList)
                    {
                        avalableCell.Parent = cell;
                        avalableCell.InOpenList = true;
                        openList.Add(avalableCell);
                        FixeCell(avalableCell, cell);
                    }
            }

            #endregion

            SortOpenList();
        }

        private void SortOpenList()
        {
            var ok = false;
            while (!ok)
            {
                ok = true;
                for (var i = 0; i < openList.Count - 1; i++)
                    if (openList[i].F > openList[i + 1].F &&
                        PathingUtils.DistanceToPoint(openList[i].Location, destinationCell.Location) <
                        PathingUtils.DistanceToPoint(openList[i + 1].Location, destinationCell.Location))
                    {
                        var temp = openList[i];
                        openList[i] = openList[i + 1];
                        openList[i + 1] = temp;
                        ok = false;
                    }
            }
        }

        private void FixeCell(Cell cellInspected, Cell currentCell)
        {
            var MovementCost = GetFixedMouvementCost(cellInspected, currentCell);
            cellInspected.G = (uint) MovementCost;
            cellInspected.H = (uint) GetFixedHeuristic(cellInspected, currentCell);
            cellInspected.F = cellInspected.G + cellInspected.H;
        }

        private double GetFixedMouvementCost(Cell cellInspected, Cell currentCell)
        {
            var poid = PointWeight(cellInspected.Location);
            return cellInspected.G + (cellInspected.Location.Y == currentCell.Location.Y ||
                                      cellInspected.Location.X == currentCell.Location.X
                       ? 10
                       : 15) * poid;
        }

        private double GetFixedHeuristic(Cell cellInspected, Cell currentCell)
        {
            var _loc8_ = cellInspected.Location.X + cellInspected.Location.Y ==
                         destinationCell.Location.X + destinationCell.Location.Y;
            var _loc9_ = cellInspected.Location.X + cellInspected.Location.Y ==
                         startCell.Location.X + startCell.Location.Y;
            var _loc10_ = cellInspected.Location.X - cellInspected.Location.Y ==
                          destinationCell.Location.X - destinationCell.Location.Y;
            var _loc11_ = cellInspected.Location.X - cellInspected.Location.Y ==
                          startCell.Location.X - startCell.Location.Y;

            var Heuristic =
                10 * Math.Sqrt(
                    (destinationCell.Location.X - cellInspected.Location.X) *
                    (destinationCell.Location.Y - cellInspected.Location.Y) +
                    (destinationCell.Location.X - cellInspected.Location.X) *
                    (destinationCell.Location.X - cellInspected.Location.X));

            if (cellInspected.Location.X == destinationCell.Location.X ||
                cellInspected.Location.Y == destinationCell.Location.Y)
                Heuristic = Heuristic - 3;
            if (_loc8_ || _loc10_ ||
                cellInspected.Location.X + cellInspected.Location.Y ==
                currentCell.Location.X + currentCell.Location.Y ||
                cellInspected.Location.X - cellInspected.Location.Y == currentCell.Location.X - currentCell.Location.Y)
                Heuristic = Heuristic - 2;
            if (cellInspected.Location.X == startCell.Location.X || cellInspected.Location.Y == startCell.Location.Y)
                Heuristic = Heuristic - 3;
            if (_loc9_ || _loc11_)
                Heuristic = Heuristic - 2;

            return Heuristic;
        }

        private double PointWeight(Point point)
        {
            double result = 1;
            int cellId = PathingUtils.CoordToCellId(point.X, point.Y);
            var speed = currentMap.Data.Cells[cellId].Speed;
            if (speed >= 0)
                result = result + (5 - speed);
            else
                result = result + (11 + Math.Abs(speed));
            return result;
        }

        #endregion
    }
}