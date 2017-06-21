using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Game.World.Pathfinding;
using Cookie.Protocol.Network.Messages.Game.Context;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.Protocol.Network.Messages.Game.Interactive;
using Cookie.Utils;
using Cookie.Utils.Enums;

namespace Cookie.Game.Map
{
    public class Map
    {
        private readonly DofusClient _client;
        private int _mapId;
        private bool _moving;
        private int _time;

        public Map(DofusClient client)
        {
            _client = client;
        }

        public bool ChangeMap(string direction)
        {
            var neighbourId = -1;
            var num2 = -1;
            switch (direction)
            {
                case "up":
                    neighbourId = _client.Account.Character.MapData.Data.TopNeighbourId;
                    num2 = 64;
                    break;
                case "bottom":
                    neighbourId = _client.Account.Character.MapData.Data.BottomNeighbourId;
                    num2 = 4;
                    break;
                case "right":
                    neighbourId = _client.Account.Character.MapData.Data.RightNeighbourId;
                    num2 = 1;
                    break;
                case "left":
                    neighbourId = _client.Account.Character.MapData.Data.LeftNeighbourId;
                    num2 = 16;
                    break;
            }
            if (num2 == -1 || neighbourId < 0) return false;
            var cellId = _client.Account.Character.CellId;
            if ((_client.Account.Character.MapData.Data.Cells[cellId].MapChangeData & num2) > 0)
            {
                LaunchChangeMap(neighbourId);
                return true;
            }
            var list = new List<int>();
            var num4 = _client.Account.Character.MapData.Data.Cells.Count - 1;
            for (var i = 0; i <= num4; i++)
            {
                if ((_client.Account.Character.MapData.Data.Cells[i].MapChangeData & num2) > 0 &&
                    _client.Account.Character.MapData.NothingOnCell(i))
                    list.Add(i);
            }
            while (list.Count > 0)
            {
                var randomCellId = list[Randomize.GetRandomNumber(0, list.Count)];
                _mapId = neighbourId;
                if (MoveToCell(randomCellId))
                    return true;
                list.Remove(randomCellId);
            }
            return false;
        }

        public bool MoveToCell(int cellid, bool gathering = false)
        {
            var timePath =
                _client.Account.Character.Pathfinder.GetPath((short)_client.Account.Character.CellId, (short)cellid);
            var path = _client.Account.Character.Pathfinder.GetCompressedPath(timePath);
            if (path == null || timePath == null)
                return false;

            _time = VelocityHelper.GetPathVelocity(timePath, path.Length < 4 ? MovementTypeEnum.Walking : MovementTypeEnum.Running);

            if (path[path.Length - 1] == _client.Account.Character.CellId)
            {
                _moving = false;
                _client.Account.Character.Status = CharacterStatus.None;
                ConfirmMove(gathering);
                return true;
            }

            var msg = new GameMapMovementRequestMessage(path.ToList(), _client.Account.Character.MapId);
            _client.Send(msg);
            ConfirmMove(gathering);
            _client.Account.Character.Status = CharacterStatus.Moving;
            _moving = true;
            return true;
        }

        public void LaunchChangeMap(int mapId)
        {
            _time = 0;
            _mapId = -1;
            var msg = new ChangeMapMessage(mapId);
            _client.Send(msg);
            Task.Factory.StartNew(CheckMapChange);
        }

        public void ConfirmMove(bool gathering = false)
        {
            Thread.Sleep(_time);
            _client.Send(new GameMapMovementConfirmMessage());
            _moving = false;
            if (gathering)
                return;
            if (_mapId != -1)
                LaunchChangeMap(_mapId);
        }

        public void UseElement(int id, int skillId)
        {
            Thread.Sleep(500);
            var msg = new InteractiveUseRequestMessage((uint)id, (uint)skillId);
            _client.Send(msg);
            _client.Logger.Log($"Récole ressource id {id}", LogMessageType.Info);
        }

        private void CheckMapChange()
        {
            var old = _client.Account.Character.MapId;
            _client.Logger.Log($"[Map] Old {old}");
            Thread.Sleep(1000);
            _client.Logger.Log($"[Map] New {_client.Account.Character.MapId}");
            if (old == _client.Account.Character.MapId)
                LaunchChangeMap(old);
        }
    }
}