using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6486;

        public TreasureHuntMessage(byte questType, int startMapId, List<TreasureHuntStep> knownStepsList,
            byte totalStepCount, uint checkPointCurrent, uint checkPointTotal, int availableRetryCount,
            List<TreasureHuntFlag> flags)
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

        public TreasureHuntMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }
        public int StartMapId { get; set; }
        public List<TreasureHuntStep> KnownStepsList { get; set; }
        public byte TotalStepCount { get; set; }
        public uint CheckPointCurrent { get; set; }
        public uint CheckPointTotal { get; set; }
        public int AvailableRetryCount { get; set; }
        public List<TreasureHuntFlag> Flags { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteInt(StartMapId);
            writer.WriteShort((short) KnownStepsList.Count);
            for (var knownStepsListIndex = 0; knownStepsListIndex < KnownStepsList.Count; knownStepsListIndex++)
            {
                var objectToSend = KnownStepsList[knownStepsListIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteByte(TotalStepCount);
            writer.WriteVarUhInt(CheckPointCurrent);
            writer.WriteVarUhInt(CheckPointTotal);
            writer.WriteInt(AvailableRetryCount);
            writer.WriteShort((short) Flags.Count);
            for (var flagsIndex = 0; flagsIndex < Flags.Count; flagsIndex++)
            {
                var objectToSend = Flags[flagsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
            StartMapId = reader.ReadInt();
            var knownStepsListCount = reader.ReadUShort();
            KnownStepsList = new List<TreasureHuntStep>();
            for (var knownStepsListIndex = 0; knownStepsListIndex < knownStepsListCount; knownStepsListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<TreasureHuntStep>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                KnownStepsList.Add(objectToAdd);
            }
            TotalStepCount = reader.ReadByte();
            CheckPointCurrent = reader.ReadVarUhInt();
            CheckPointTotal = reader.ReadVarUhInt();
            AvailableRetryCount = reader.ReadInt();
            var flagsCount = reader.ReadUShort();
            Flags = new List<TreasureHuntFlag>();
            for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
            {
                var objectToAdd = new TreasureHuntFlag();
                objectToAdd.Deserialize(reader);
                Flags.Add(objectToAdd);
            }
        }
    }
}