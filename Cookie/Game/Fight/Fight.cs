using System.Linq;
using Cookie.API.Core;
using Cookie.API.Game.Fight;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Game.Map;
using Cookie.Game.Map;
using Cookie.API.Utils;

namespace Cookie.Game.Fight
{
    public class Fight : FightData, IFight
    {
        public Fight(IAccount account) : base(account)
        {
        }

        public void EndTurn()
        {
            if (Account.Character.Fight.Fighter.MovementPoints > 0)
            {
                var fighter = NearestMonster();
                var reachableCells = GetReachableCells();
                var cellId = -1;
                var savDistance = -1;
                foreach (var cell in reachableCells)
                {
                    var reachableCellPoint = new MapPoint(cell);
                    var distance = 0;
                    distance = (distance + reachableCellPoint.DistanceToCell(new MapPoint(fighter.CellId)));
                    if (((savDistance == -1) || (distance < savDistance)))
                    {
                        cellId = cell;
                        savDistance = distance;
                    }
                }
                var movement = MoveToCell(cellId);
                movement.MovementFinished += (sender, e) =>
                {
                    if (e.Sucess)
                    {
                        Logger.Default.Log($"Déplacement sur la cellId {movement.EndCell} réussi ");
                        Account.Network.SendToServer(new GameFightTurnFinishMessage());
                        IsFighterTurn = false;
                    }
                    else
                    {
                        Logger.Default.Log($"Déplacement sur la cellId {movement.EndCell} échoué ");
                        Account.Network.SendToServer(new GameFightTurnFinishMessage());
                        IsFighterTurn = false;
                    }
                };
                movement.PerformMovement();
            }
            else
            {
                Account.Network.SendToServer(new GameFightTurnFinishMessage());
                IsFighterTurn = false;
            }

            //Account.Network.SendToServer(new GameFightTurnFinishMessage());
            //IsFighterTurn = false;
        }

        public void LockFight()
        {
            Account.Network.SendToServer(
                new GameFightOptionToggleMessage((byte)FightOptionsEnum.FIGHT_OPTION_SET_CLOSED));
        }

        public void SetReady()
        {
            Account.Network.SendToServer(new GameFightReadyMessage(true));
        }

        public void KickPlayer(int id)
        {
            Account.Network.SendToServer(new GameContextKickMessage(id));
        }

        public ICellMovement MoveToCell(int cellId)
        {
            ICellMovement toReturn;
            if (cellId != Fighter.CellId)
            {
                if (!IsCellWalkable(cellId))
                {
                    var num = -1;
                    var num2 = 5000;
                    var point = new MapPoint(Fighter.CellId);
                    var point2 = new MapPoint(cellId);
                    var direction = 1;
                    while (true)
                    {
                        var nearestCellInDirection = point2.GetNearestCellInDirection(direction, 1);
                        if (IsCellWalkable(nearestCellInDirection.CellId))
                        {
                            var num4 = point.DistanceToCell(nearestCellInDirection);
                            if (num4 < num2)
                            {
                                num2 = num4;
                                num = nearestCellInDirection.CellId;
                            }
                        }
                        direction = direction + 2;
                        if (direction > 7)
                        {
                            if (num == -1)
                                return null;
                            cellId = num;
                            break;
                        }
                    }
                }
                var pathfinder = new SimplePathfinder((API.Gamedata.D2p.Map)Account.Character.Map.Data);
                pathfinder.SetFight(Fighters, Fighter.MovementPoints);
                var path = pathfinder.FindPath(Fighter.CellId, cellId);
                if (path != null)
                {
                    toReturn = new CellMovement(Account, path);
                    return toReturn;
                }
            }
            return null;
        }

        public void LaunchSpell(int spellId, int cellId)
        {
            lock (CheckLock)
            {
                foreach (var fighter in Fighters)
                    if (fighter.CellId == cellId)
                    {
                        Account.Network.SendToServer(
                            new GameActionFightCastOnTargetRequestMessage((ushort)spellId, fighter.Id));
                        return;
                    }
            }
            Account.Network.SendToServer(new GameActionFightCastRequestMessage((ushort)spellId, (short)cellId));
        }
    }
}