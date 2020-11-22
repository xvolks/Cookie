using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AllianceInsiderPrismInformation : PrismInformation
    {
        public new const ushort ProtocolId = 431;

        public override ushort TypeID => ProtocolId;

        public int LastTimeSlotModificationDate { get; set; }
        public uint LastTimeSlotModificationAuthorGuildId { get; set; }
        public ulong LastTimeSlotModificationAuthorId { get; set; }
        public string LastTimeSlotModificationAuthorName { get; set; }
        public List<ObjectItem> ModulesObjects { get; set; }
        public AllianceInsiderPrismInformation() { }

        public AllianceInsiderPrismInformation( int LastTimeSlotModificationDate, uint LastTimeSlotModificationAuthorGuildId, ulong LastTimeSlotModificationAuthorId, string LastTimeSlotModificationAuthorName, List<ObjectItem> ModulesObjects ){
            this.LastTimeSlotModificationDate = LastTimeSlotModificationDate;
            this.LastTimeSlotModificationAuthorGuildId = LastTimeSlotModificationAuthorGuildId;
            this.LastTimeSlotModificationAuthorId = LastTimeSlotModificationAuthorId;
            this.LastTimeSlotModificationAuthorName = LastTimeSlotModificationAuthorName;
            this.ModulesObjects = ModulesObjects;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastTimeSlotModificationDate);
            writer.WriteVarUhInt(LastTimeSlotModificationAuthorGuildId);
            writer.WriteVarUhLong(LastTimeSlotModificationAuthorId);
            writer.WriteUTF(LastTimeSlotModificationAuthorName);
			writer.WriteShort((short)ModulesObjects.Count);
			foreach (var x in ModulesObjects)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LastTimeSlotModificationDate = reader.ReadInt();
            LastTimeSlotModificationAuthorGuildId = reader.ReadVarUhInt();
            LastTimeSlotModificationAuthorId = reader.ReadVarUhLong();
            LastTimeSlotModificationAuthorName = reader.ReadUTF();
            var ModulesObjectsCount = reader.ReadShort();
            ModulesObjects = new List<ObjectItem>();
            for (var i = 0; i < ModulesObjectsCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ModulesObjects.Add(objectToAdd);
            }
        }
    }
}
