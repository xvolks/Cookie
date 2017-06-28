using System.Collections.Generic;
using Cookie.API.Game.Map.Elements;

namespace Cookie.API.Game.Jobs
{
    public interface IGatherManager
    {
        int Id { get; set; }
        bool IsFishing { get; set; }
        bool Moved { get; set; }
        bool Launched { get; set; }
        List<int> ToGather { get; set; }
        bool AutoGather { get; set; }

        object Gather();
        object Gather(List<int> resourcesId, bool autoGather);

        List<IUsableElement> TrierDistanceElement(List<int> listDistance,
            List<IUsableElement> listUsableElement);
    }
}