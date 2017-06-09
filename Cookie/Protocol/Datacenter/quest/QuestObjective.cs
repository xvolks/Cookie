

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;
using Cookie.Datacenter;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("QuestObjectives")]
    public class QuestObjective : IDataObject
    {
        public const String MODULE = "QuestObjectives";
        public uint Id;
        public uint StepId;
        public uint TypeId;
        public int DialogId;
        public QuestObjectiveParameters Parameters;
        public Point Coords;
        public int MapId;
        public QuestObjectiveType Type;
    }
}