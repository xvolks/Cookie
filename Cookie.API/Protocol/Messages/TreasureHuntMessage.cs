using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6486;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public double StartMapId { get; set; }
        public List<TreasureHuntStep> KnownStepsList { get; set; }
        public sbyte TotalStepCount { get; set; }
        public uint CheckPointCurrent { get; set; }
        public uint CheckPointTotal { get; set; }
        public int AvailableRetryCount { get; set; }
        public List<TreasureHuntFlag> Flags { get; set; }
        public TreasureHuntMessage() { }

        public TreasureHuntMessage( sbyte QuestType, double StartMapId, List<TreasureHuntStep> KnownStepsList, sbyte TotalStepCount, uint CheckPointCurrent, uint CheckPointTotal, int AvailableRetryCount, List<TreasureHuntFlag> Flags ){
            this.QuestType = QuestType;
            this.StartMapId = StartMapId;
            this.KnownStepsList = KnownStepsList;
            this.TotalStepCount = TotalStepCount;
            this.CheckPointCurrent = CheckPointCurrent;
            this.CheckPointTotal = CheckPointTotal;
            this.AvailableRetryCount = AvailableRetryCount;
            this.Flags = Flags;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteDouble(StartMapId);
			writer.WriteShort((short)KnownStepsList.Count);
			foreach (var x in KnownStepsList)
			{
				x.Serialize(writer);
			}
            writer.WriteSByte(TotalStepCount);
            writer.WriteVarUhInt(CheckPointCurrent);
            writer.WriteVarUhInt(CheckPointTotal);
            writer.WriteInt(AvailableRetryCount);
			writer.WriteShort((short)Flags.Count);
			foreach (var x in Flags)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            StartMapId = reader.ReadDouble();
            var KnownStepsListCount = reader.ReadShort();
            KnownStepsList = new List<TreasureHuntStep>();
            for (var i = 0; i < KnownStepsListCount; i++)
            {
                TreasureHuntStep objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                KnownStepsList.Add(objectToAdd);
            }
            TotalStepCount = reader.ReadSByte();
            CheckPointCurrent = reader.ReadVarUhInt();
            CheckPointTotal = reader.ReadVarUhInt();
            AvailableRetryCount = reader.ReadInt();
            var FlagsCount = reader.ReadShort();
            Flags = new List<TreasureHuntFlag>();
            for (var i = 0; i < FlagsCount; i++)
            {
                var objectToAdd = new TreasureHuntFlag();
                objectToAdd.Deserialize(reader);
                Flags.Add(objectToAdd);
            }
        }
    }
}
