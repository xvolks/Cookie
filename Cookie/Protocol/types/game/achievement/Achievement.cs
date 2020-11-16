using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class Achievement : NetworkType
    {
        public const short ProtocolId = 363;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;
        public List<AchievementObjective> FinishedObjective;
        public List<AchievementStartedObjective> StartedObjectives;

        public Achievement()
        {
        }

        public Achievement(
            short id_,
            List<AchievementObjective> finishedObjective,
            List<AchievementStartedObjective> startedObjectives
        )
        {
            Id_ = id_;
            FinishedObjective = finishedObjective;
            StartedObjectives = startedObjectives;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteShort((short)FinishedObjective.Count());
            foreach (var current in FinishedObjective)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)StartedObjectives.Count());
            foreach (var current in StartedObjectives)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            var countFinishedObjective = reader.ReadShort();
            FinishedObjective = new List<AchievementObjective>();
            for (short i = 0; i < countFinishedObjective; i++)
            {
                AchievementObjective type = new AchievementObjective();
                type.Deserialize(reader);
                FinishedObjective.Add(type);
            }
            var countStartedObjectives = reader.ReadShort();
            StartedObjectives = new List<AchievementStartedObjective>();
            for (short i = 0; i < countStartedObjectives; i++)
            {
                AchievementStartedObjective type = new AchievementStartedObjective();
                type.Deserialize(reader);
                StartedObjectives.Add(type);
            }
        }
    }
}