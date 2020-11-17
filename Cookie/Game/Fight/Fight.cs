using System;
using Cookie.API.Core;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Map;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.Game.Fight.Spell;
using Cookie.Game.Map;

namespace Cookie.Game.Fight
{
    public class Fight : FightData, IFight
    {
        public Fight(IAccount account) : base(account)
        {
            Attach();
        }

        public void EndTurn()
        {
            if (Account.Character.Fight.Fighter.MovementPoints > 0 &&
                Account.Character.Fight.Fighter.Stats.DodgePALostProbability == 0)
            {
                var monster = Account.Character.Fight.NearestMonster();
                var reachableCells = Account.Character.Fight.GetReachableCells();
                var cellId = -1;
                var savDistance = -1;
                foreach (var cell in reachableCells)
                {
                    var reachableCellPoint = new MapPoint(cell);
                    var distance = 0;
                    distance += reachableCellPoint.DistanceToCell(new MapPoint(monster.CellId));
                    if (savDistance != -1 && distance >= savDistance) continue;
                    cellId = cell;
                    savDistance = distance;
                }
                var movementt = Account.Character.Fight.MoveToCell(cellId);
                movementt.MovementFinished += (sender, e) =>
                {
                    Logger.Default.Log("Fin du tour");
                    Account.Network.SendToServer(new GameFightTurnFinishMessage());
                    IsFighterTurn = false;
                };
                movementt.PerformMovement();
            }
            else
            {
                Account.Network.SendToServer(new GameFightTurnFinishMessage());
                IsFighterTurn = false;
            }
        }

        public void LockFight()
        {
            Account.Network.SendToServer( new GameFightOptionToggleMessage((sbyte) FightOptionsEnum.FIGHT_OPTION_SET_CLOSED));
        }
        public void LockObserver()
        {
            Account.Network.SendToServer( new GameFightOptionToggleMessage((sbyte) FightOptionsEnum.FIGHT_OPTION_SET_SECRET));
        }
        public void LockPartyOnly()
        {
            Account.Network.SendToServer( new GameFightOptionToggleMessage((sbyte) FightOptionsEnum.FIGHT_OPTION_SET_TO_PARTY_ONLY));
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
            if (cellId == Fighter.CellId) return null;
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
                    direction += 2;
                    if (direction <= 7) continue;
                    if (num == -1)
                        return null;
                    cellId = num;
                    break;
                }
            }
            var pathfinder = new SimplePathfinder((API.Gamedata.D2p.Map) Account.Character.Map.Data);
            pathfinder.SetFight(Fighters, Fighter.MovementPoints);
            var path = pathfinder.FindPath(Fighter.CellId, cellId);
            return path == null ? null : new CellMovement(Account, path);
        }
        public event Action<GameActionFightSpellCastMessage> SpellCasted;
        public event Action<GameActionFightCloseCombatMessage> CloseCombatCasted;

        private void Attach()
        {
            //Logger.Default.Log("Register Fight Packet");
            Account.Network.RegisterPacket<GameActionFightSpellCastMessage>(HandleGameActionFightSpellCastMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightJoinMessage>(HandleGameFightJoinMessage, MessagePriority.High);
            Account.Network.RegisterPacket<GameActionFightCloseCombatMessage>(HandleGameActionFightCloseCombatMessage, MessagePriority.Normal);
        }

        private void HandleGameActionFightSpellCastMessage(IAccount account, GameActionFightSpellCastMessage message)
        {
            SpellCasted?.Invoke(message);
        }
        private void HandleGameActionFightCloseCombatMessage(IAccount account, GameActionFightCloseCombatMessage message)
        {
            CloseCombatCasted?.Invoke(message);
        }

        private void HandleGameFightJoinMessage(IAccount account, GameFightJoinMessage message)
        {
            Account.Network.SendToServer(new GameFightOptionToggleMessage(2));
        }
    }
}