using System.Collections.Generic;

namespace Cookie.API.Game.Job
{
    public interface IGatherManager
    {
        List<int> BannedElementId { get; set; }

        bool GoGather(int elemTypeId);
    }
}