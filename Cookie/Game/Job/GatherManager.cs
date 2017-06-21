using System.Collections.Generic;
using Cookie.Core;
using Cookie.Protocol.Network.Types.Game.Interactive;
using Cookie.Utils.Enums;

namespace Cookie.Game.Job
{
    public class GatherManager
    {
        private readonly DofusClient _client;

        private InteractiveElement _tempElement;

        public GatherManager(DofusClient client)
        {
            _client = client;
            BannedElementId = new List<int>();
        }

        public List<int> BannedElementId { get; set; }

        public bool GoGather(int elemTypeId)
        {
            _tempElement =
                _client.Account.Character.MapData.InteractiveElements.Find(
                    e => e.ElementTypeId == elemTypeId && e.EnabledSkills.Count > 0 &&
                         !BannedElementId.Contains(elemTypeId));
            if (_tempElement == null)
                return false;
            var statedElement =
                _client.Account.Character.MapData.StatedElements.Find(
                    e => e.ElementId == _tempElement.ElementId && e.ElementState == 0);
            if (statedElement == null)
                return false;
            if (!_client.Account.Character.Map.MoveToCell(statedElement.ElementCellId - 1)) return false;
            _client.Account.Character.Status = CharacterStatus.Gathering;
            _client.Account.Character.Map.UseElement(_tempElement.ElementId,
                _tempElement.EnabledSkills[0].SkillInstanceUid);

            _client.Account.Character.MapData.InteractiveElements.Remove(
                _client.Account.Character.MapData.InteractiveElements.Find(x => x.ElementId == _tempElement.ElementId));
            _client.Account.Character.MapData.StatedElements.Remove(
                _client.Account.Character.MapData.StatedElements.Find(
                    x => x.ElementCellId == statedElement.ElementCellId));

            _tempElement = null;
            return true;
        }
    }
}