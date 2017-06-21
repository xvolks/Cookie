// Generated on 12/06/2016 11:35:52

using Cookie.Gamedata.D2o;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("QuestObjectives")]
    public class QuestObjective : IDataObject
    {
        public const string MODULE = "QuestObjectives";
        public Point Coords;
        public int DialogId;
        public uint Id;
        public int MapId;
        public QuestObjectiveParameters Parameters;
        public uint StepId;
        public QuestObjectiveType Type;
        public uint TypeId;
    }
}