using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntMessage : NetworkMessage
    {
        public const uint ProtocolId = 6486;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;
        public double StartMapId = 0;
        public List<TreasureHuntStep> KnownStepsList;
        public byte TotalStepCount = 0;
        public int CheckPointCurrent = 0;
        public int CheckPointTotal = 0;
        public int AvailableRetryCount = 0;
        public List<TreasureHuntFlag> Flags;

        public TreasureHuntMessage()
        {
        }

        public TreasureHuntMessage(
            byte questType,
            double startMapId,
            List<TreasureHuntStep> knownStepsList,
            byte totalStepCount,
            int checkPointCurrent,
            int checkPointTotal,
            int availableRetryCount,
            List<TreasureHuntFlag> flags
        )
        {
            QuestType = questType;
            StartMapId = startMapId;
            KnownStepsList = knownStepsList;
            TotalStepCount = totalStepCount;
            CheckPointCurrent = checkPointCurrent;
            CheckPointTotal = checkPointTotal;
            AvailableRetryCount = availableRetryCount;
            Flags = flags;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteDouble(StartMapId);
            writer.WriteShort((short)KnownStepsList.Count());
            foreach (var current in KnownStepsList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteByte(TotalStepCount);
            writer.WriteVarInt(CheckPointCurrent);
            writer.WriteVarInt(CheckPointTotal);
            writer.WriteInt(AvailableRetryCount);
            writer.WriteShort((short)Flags.Count());
            foreach (var current in Flags)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
            StartMapId = reader.ReadDouble();
            var countKnownStepsList = reader.ReadShort();
            KnownStepsList = new List<TreasureHuntStep>();
            for (short i = 0; i < countKnownStepsList; i++)
            {
                var knownStepsListtypeId = reader.ReadShort();
                TreasureHuntStep type = new TreasureHuntStep();
                type.Deserialize(reader);
                KnownStepsList.Add(type);
            }
            TotalStepCount = reader.ReadByte();
            CheckPointCurrent = reader.ReadVarInt();
            CheckPointTotal = reader.ReadVarInt();
            AvailableRetryCount = reader.ReadInt();
            var countFlags = reader.ReadShort();
            Flags = new List<TreasureHuntFlag>();
            for (short i = 0; i < countFlags; i++)
            {
                TreasureHuntFlag type = new TreasureHuntFlag();
                type.Deserialize(reader);
                Flags.Add(type);
            }
        }
    }
}