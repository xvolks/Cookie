using Cookie.API.Game.Fight;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Game.World.Pathfinding;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Core;

namespace Cookie.Game.Fight
{
    public class Fight : FightData, IFight
    {

        public Fight(IAccount account) : base(account)
        {
        }
        public void EndTurn()
        {
            Account.Network.SendToServer(new GameFightTurnFinishMessage());
            IsFighterTurn = false;
        }
        public void LockFight()
        {
            Account.Network.SendToServer(new GameFightOptionToggleMessage(2));
        }
        public void SetReady()
        {
            Account.Network.SendToServer(new GameFightReadyMessage(true));
        }
        public void KickPlayer(int id)
        {
            Account.Network.SendToServer(new GameContextKickMessage(id));
        }
        public bool MoveToCell(int cellId)
        {
            if (cellId != Fighter.CellId)
            {
                if (!(IsCellWalkable(cellId)))
                {
                    int num = -1;
                    int num2 = 5000;
                    MapPoint point = new MapPoint(Fighter.CellId);
                    MapPoint point2 = new MapPoint(cellId);
                    int direction = 1;
                    while (true)
                    {
                        MapPoint nearestCellInDirection = point2.GetNearestCellInDirection(direction, 1);
                        if (IsCellWalkable(nearestCellInDirection.CellId))
                        {
                            int num4 = point.DistanceToCell(nearestCellInDirection);
                            if (num4 < num2)
                            {
                                num2 = num4;
                                num = nearestCellInDirection.CellId;
                            }
                        }
                        direction = (direction + 2);
                        if (direction > 7)
                        {
                            if (num == -1)
                                return false;
                            cellId = num;
                            break;
                        }
                    }
                }
                SimplePathfinder pathfinder = new SimplePathfinder((API.Gamedata.D2p.Map)Account.Character.Map.Data);
                MovementPath path = pathfinder.FindPath(Fighter.CellId, cellId);
                if (path != null)
                {
                    List<uint> serverMovement = MapMovementAdapter.GetServerMovement(path);
                    Account.Network.SendToServer(new GameMapMovementRequestMessage(serverMovement.ToList().Select<uint, short>(ui => (short)ui).ToList(), Account.Character.Map.Id));
                    return true;
                }
            }
            return false;
        }
        public void LaunchSpell(int spellId, int cellId)
        {
            lock (this.CheckLock)
            {
                foreach (var fighter in Fighters)
                {
                    if (fighter.CellId == cellId)
                    {
                        Account.Network.SendToServer(new GameActionFightCastOnTargetRequestMessage((ushort)spellId, fighter.Id));
                        return;
                    }
                }
            }
            Account.Network.SendToServer(new GameActionFightCastRequestMessage((ushort)spellId, (short)cellId));
        }
    }
}
