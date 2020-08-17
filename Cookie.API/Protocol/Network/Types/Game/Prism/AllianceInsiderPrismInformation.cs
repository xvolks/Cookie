using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Prism
{
    public class AllianceInsiderPrismInformation : PrismInformation
    {
        public new const ushort ProtocolId = 431;

        public AllianceInsiderPrismInformation(int lastTimeSlotModificationDate,
            uint lastTimeSlotModificationAuthorGuildId, ulong lastTimeSlotModificationAuthorId,
            string lastTimeSlotModificationAuthorName, List<ObjectItem> modulesObjects)
        {
            LastTimeSlotModificationDate = lastTimeSlotModificationDate;
            LastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
            LastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
            LastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
            ModulesObjects = modulesObjects;
        }

        public AllianceInsiderPrismInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int LastTimeSlotModificationDate { get; set; }
        public uint LastTimeSlotModificationAuthorGuildId { get; set; }
        public ulong LastTimeSlotModificationAuthorId { get; set; }
        public string LastTimeSlotModificationAuthorName { get; set; }
        public List<ObjectItem> ModulesObjects { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastTimeSlotModificationDate);
            writer.WriteVarUhInt(LastTimeSlotModificationAuthorGuildId);
            writer.WriteVarUhLong(LastTimeSlotModificationAuthorId);
            writer.WriteUTF(LastTimeSlotModificationAuthorName);
            writer.WriteShort((short) ModulesObjects.Count);
            for (var modulesObjectsIndex = 0; modulesObjectsIndex < ModulesObjects.Count; modulesObjectsIndex++)
            {
                var objectToSend = ModulesObjects[modulesObjectsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LastTimeSlotModificationDate = reader.ReadInt();
            LastTimeSlotModificationAuthorGuildId = reader.ReadVarUhInt();
            LastTimeSlotModificationAuthorId = reader.ReadVarUhLong();
            LastTimeSlotModificationAuthorName = reader.ReadUTF();
            var modulesObjectsCount = reader.ReadUShort();
            ModulesObjects = new List<ObjectItem>();
            for (var modulesObjectsIndex = 0; modulesObjectsIndex < modulesObjectsCount; modulesObjectsIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ModulesObjects.Add(objectToAdd);
            }
        }
    }
}