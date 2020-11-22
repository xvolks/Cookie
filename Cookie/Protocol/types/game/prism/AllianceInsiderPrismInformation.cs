using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class AllianceInsiderPrismInformation : PrismInformation
    {
        public new const short ProtocolId = 431;
        public override short TypeId { get { return ProtocolId; } }

        public int LastTimeSlotModificationDate = 0;
        public int LastTimeSlotModificationAuthorGuildId = 0;
        public long LastTimeSlotModificationAuthorId = 0;
        public string LastTimeSlotModificationAuthorName;
        public List<ObjectItem> ModulesObjects;

        public AllianceInsiderPrismInformation(): base()
        {
        }

        public AllianceInsiderPrismInformation(
            byte typeId_,
            byte state,
            int nextVulnerabilityDate,
            int placementDate,
            int rewardTokenCount,
            int lastTimeSlotModificationDate,
            int lastTimeSlotModificationAuthorGuildId,
            long lastTimeSlotModificationAuthorId,
            string lastTimeSlotModificationAuthorName,
            List<ObjectItem> modulesObjects
        ): base(
            typeId_,
            state,
            nextVulnerabilityDate,
            placementDate,
            rewardTokenCount
        )
        {
            LastTimeSlotModificationDate = lastTimeSlotModificationDate;
            LastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
            LastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
            LastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
            ModulesObjects = modulesObjects;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastTimeSlotModificationDate);
            writer.WriteVarInt(LastTimeSlotModificationAuthorGuildId);
            writer.WriteVarLong(LastTimeSlotModificationAuthorId);
            writer.WriteUTF(LastTimeSlotModificationAuthorName);
            writer.WriteShort((short)ModulesObjects.Count());
            foreach (var current in ModulesObjects)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LastTimeSlotModificationDate = reader.ReadInt();
            LastTimeSlotModificationAuthorGuildId = reader.ReadVarInt();
            LastTimeSlotModificationAuthorId = reader.ReadVarLong();
            LastTimeSlotModificationAuthorName = reader.ReadUTF();
            var countModulesObjects = reader.ReadShort();
            ModulesObjects = new List<ObjectItem>();
            for (short i = 0; i < countModulesObjects; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                ModulesObjects.Add(type);
            }
        }
    }
}