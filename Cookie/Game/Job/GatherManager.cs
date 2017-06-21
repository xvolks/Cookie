using System.Threading;
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
        }

        public bool GoGather(int elemId)
        {
            _tempElement =
                _client.Account.Character.MapData.InteractiveElements.Find(
                    e => e.ElementTypeId == elemId && e.EnabledSkills.Count > 0);
            if (_tempElement == null)
                return false;
            var statedElement =
                _client.Account.Character.MapData.StatedElements.Find(e => e.ElementId == _tempElement.ElementId && e.ElementState == 0);
            if (statedElement == null)
                return false;
            if (!_client.Account.Character.Map.MoveToCell(statedElement.ElementCellId - 1, true)) return false;
            _client.Account.Character.Status = CharacterStatus.Gathering;
            Thread.Sleep(100);
            _client.Account.Character.Map.UseElement(_tempElement.ElementId, _tempElement.EnabledSkills[0].SkillInstanceUid);
            _tempElement = null;
            return true;
        }
    }
}
